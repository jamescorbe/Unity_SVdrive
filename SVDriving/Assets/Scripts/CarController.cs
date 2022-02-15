using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private float SteerAngle;
    private float CurrentBreakForce;
    private bool Breaking;

    [SerializeField] private float EngineForce;
    [SerializeField] private float BreakForce;
    [SerializeField] private float MaxSteeringAngle;

    [SerializeField] private WheelCollider FrontLeftWheelCollider; // SerializeFeild used to show private values in the editor
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider RearLeftWheelCollider;
    [SerializeField] private WheelCollider RearRightWheelCollider;

    [SerializeField] private Transform FrontLeftWheelTransform; // Serializeing the transforms used to show the wheels movement
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;
    private void FixedUpdate()
    {
        GetUserInput();
        ControlEngine();
        Controlsteering();
        UpdateWheelPos();
    }
    private void GetUserInput() // getting the user input for stearing , acceleration and breaking.
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        Breaking = Input.GetKey(KeyCode.Space);
    }
    private void ControlEngine()
    {
        FrontLeftWheelCollider.motorTorque = VerticalInput * EngineForce;
        FrontRightWheelCollider.motorTorque = VerticalInput * EngineForce;
        CurrentBreakForce = Breaking ? BreakForce : 0f;
        ApplyBreak();
        
    }
    private void ApplyBreak()
    {
        FrontLeftWheelCollider.motorTorque = CurrentBreakForce;
        FrontRightWheelCollider.motorTorque = CurrentBreakForce;
        RearLeftWheelCollider.motorTorque = CurrentBreakForce;
        RearRightWheelCollider.motorTorque = CurrentBreakForce;
    }

    private void Controlsteering()
    {
        CurrentSteeringAngle = MaxSteeringAngle * HorizontalInput;
        FrontLeftWheelCollider.SteerAngle = CurrentSteeringAngle;
        FrontRightWheelCollider.SteerAngle = CurrentSteeringAngle;

    }
    private void UpdateWheelPos()
    {
        UpdateSingleWheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateSingleWheel(FrontRightWheelCollider, FrontRightWheelTransform);
        UpdateSingleWheel(RearLeftWheelCollider,RearLeftWheelTransform);
        UpdateSingleWheel(RearRightWheelCollider, RearRightWheelTransform);


    }
    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        WheelTransform.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;

    }


}
