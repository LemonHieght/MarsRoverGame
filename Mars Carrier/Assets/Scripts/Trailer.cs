using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    public Rigidbody sphereRB;
    public Rigidbody carRB;
    public LayerMask groundLayer;

    public float turnSpeed;
    public float airGravityMulti = 9.8f;
    public float airDrag;
    public float groundDrag;
    
    
    private float turnInput;
    private bool grounded;
    void Start()
    {
        //detaches the Controller
        sphereRB.transform.parent = null;
        carRB.transform.parent = null;
    }
    
    void Update()
    {
        
        //set Vehicle position to controller
        transform.position = sphereRB.transform.position;
        
        float newRotation = turnInput * turnSpeed * Time.deltaTime;
        transform.Rotate(0, newRotation, 0, Space.World);
        
        


        if (grounded)
        {
            sphereRB.drag = groundDrag;
        }
        else
        {
            sphereRB.drag = airDrag;
        }
    }

    //Inputs


    
    private void FixedUpdate()
    {
        if (!grounded)
        {
            sphereRB.AddForce(transform.up * -airGravityMulti);
        }

        
        RaycastHit hit;
        grounded = Physics.Raycast(transform.position, -transform.up,out hit, 1f, groundLayer);
        
        carRB.rotation = Quaternion.FromToRotation(carRB.transform.up, hit.normal) * carRB.rotation;
        
        // carRB.MoveRotation(transform.rotation);
        transform.rotation = carRB.rotation;
    }
}
