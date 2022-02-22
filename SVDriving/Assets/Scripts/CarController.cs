using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private bool IncreaseSpeed;
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


    private void Update()
    {
        GetDriverInput();
        MotorandSteering();
        PassWheelValues();
        Breaking();
    }


    private void GetDriverInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        BreakingState = Input.GetKey(KeyCode.Space);
        IncreaseSpeed = Input.GetKey(KeyCode.LeftShift);
    }

    private void MotorandSteering()
    {
        CarSteeringAngle = MaxSteeringAngle * HorizontalInput;

        FrontLeftWheelCollider.steerAngle = CarSteeringAngle; // wheel coliders in unity have the property steerAngle which is being set to the cars current steering angle for each wheel.
        FrontRightWheelCollider.steerAngle = CarSteeringAngle;

        FrontLeftWheelCollider.motorTorque = VerticalInput * EngineForce;
        FrontRightWheelCollider.motorTorque = VerticalInput * EngineForce;

    }
    private void PassWheelValues()
    {
        UpdateAllWheels(FrontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateAllWheels(FrontRightWheelCollider, FrontRightWheelTransform);
        UpdateAllWheels(RearLeftWheelCollider, RearLeftWheelTransform);
        UpdateAllWheels(RearRightWheelCollider, RearRightWheelTransform);
    }





    private void UpdateAllWheels(WheelCollider wheelcollider, Transform transform )
    {
        Quaternion WRotation;
        Vector3 WPosition;

        wheelcollider.GetWorldPose(out WPosition, out WRotation);
        transform = wheelcollider.transform.GetChild(0);
        transform.rotation = WRotation;
        transform.position = WPosition;

    }

    private void Breaking()
    {
        if (BreakingState = true)
        {
            FrontLeftWheelCollider.brakeTorque = BrakeForce;
            FrontRightWheelCollider.brakeTorque = BrakeForce;
            RearLeftWheelCollider.brakeTorque = BrakeForce;
            RearRightWheelCollider.brakeTorque = BrakeForce;
        }
    }
    



}
