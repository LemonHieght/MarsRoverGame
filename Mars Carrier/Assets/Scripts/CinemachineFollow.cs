using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CinemachineFreeLook))]
public class CinemachineFollow : MonoBehaviour
{
    private CinemachineFreeLook cam;
    public Joystick rightStick;
    private Vector2 delta;

    public float xLookSpeed;
    public float yLookSpeed;
    private void Awake()
    {
        
        cam = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        cam.m_XAxis.Value += rightStick.Horizontal * xLookSpeed * Time.deltaTime;
        cam.m_YAxis.Value += rightStick.Vertical * yLookSpeed * Time.deltaTime;
    }
}
