using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Rigidbody sphereRB;
    public Rigidbody carRB;
    public LayerMask groundLayer;
    public float smoothAngleTime = 0.5f ;

    public float moveSpeed;
    public float revMulti;
    public float turnSpeed;
    public float airGravityMulti = 9.8f;
    public float airDrag;
    public float groundDrag;
    public Joystick leftStick;


    private float moveInput;
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
        
        //gets inputs
        PlayerInput();

        float newRotation = turnInput * turnSpeed * Time.deltaTime * moveInput;
        
        //speed for forward or reverse
        moveInput *= moveInput > 0 ? moveSpeed : moveSpeed / revMulti;
        
        // turning
        transform.Rotate(0, newRotation, 0, Space.World);

        RaycastHit hit;
        grounded = Physics.Raycast(transform.position, -transform.up,out hit, 1f, groundLayer);
        
        Quaternion toRotateTo = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotateTo, smoothAngleTime *Time.deltaTime);

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
    public void PlayerInput()
    {
        // moveInput = Input.GetAxisRaw("Vertical");
        // turnInput = Input.GetAxisRaw("Horizontal");
        
        moveInput = leftStick.Vertical;
        turnInput = leftStick.Horizontal;
        
        // Debug.Log(moveInput);
    }

    
    private void FixedUpdate()
    {
        if (grounded)
        {
            //vrooooom
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            sphereRB.AddForce(transform.up * -airGravityMulti);
        }
        
        carRB.MoveRotation(transform.rotation);
    }
}
