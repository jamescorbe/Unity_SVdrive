using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private float CarSteeringAngle;
    private bool BreakingState;
    public float MaxSteeringAngle = 25f;
    public float EngineForce = 50f;
    public float BrakeForce = 0f;

    public WheelCollider FrontLeftWheelCollider;// setting wheel colliders
    public WheelCollider FrontRightWheelCollider;
    public WheelCollider RearLeftWheelCollider;
    public WheelCollider RearRightWheelCollider;

    public Transform FrontLeftWheelTransform; //setting wheel transforms
    public Transform FrontRightWheelTransform;
    public Transform RearLeftWheelTransform;
    public Transform RearRightWheelTransform;


    private void FixedUpdate()
    {
        GetDriverInput();
        MotorandSteering();
        Breaking();
        UpdateWheels();
    }


    GetDriverInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        BreakingState = Input.GetKey(KeyCode.Space);
        Increasespeed = Input.GetKey(KeyCode.LeftShift);
    }

    private void MotorandSteering()
    {
        SteeringAngle = maxSteeringAngle * HorizontalInput;

        FrontLeftWheelCollider.steerAngle = CarSteeringAngle // wheel coliders in unity have the property steerAngle which is being set to the cars current steering angle for each wheel.
        FrontRightWheelCollider.steerAngle = CarSteeringAngle;

        FrontLeftWheelCollider.motorTorque = verticalInput * EngineForce;
        FrontRightWheelCollider.motorTorque = verticalInput * EngineForce;

    }

    private void Breaking()
    {
        if (isBreaking = true)
        {
            FrontLeftWheelCollider.brakeTorque = BrakeForce;
            FrontRightWheelCollider.brakeTorque = BrakeForce;
            RearLeftWheelCollider.brakeTorque = BrakeForce;
            RearRightWheelCollider.brakeTorque = BrakeForce;
        }
    }




}
