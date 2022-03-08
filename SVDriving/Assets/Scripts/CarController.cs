using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private bool Fastmode;
    private float CarSteeringAngle;
    public bool BreakingState;
    public float MaxSteeringAngle;
    public float ActiveBreakForce;
    public float Maxspeed;

    [SerializeField] public float EngineForce;
    [SerializeField] public float CurrentSpeed;
    [SerializeField] private float BrakeForce;

    [SerializeField] public WheelCollider FrontLeftWheelCollider;// setting wheel colliders
    [SerializeField] public WheelCollider FrontRightWheelCollider;
    [SerializeField] public WheelCollider RearLeftWheelCollider;
    [SerializeField] public WheelCollider RearRightWheelCollider;

    [SerializeField] public Transform FrontLeftWheelTransform; //setting wheel transforms
    [SerializeField] public Transform FrontRightWheelTransform;
    [SerializeField] public Transform RearLeftWheelTransform;
    [SerializeField] public Transform RearRightWheelTransform;


    private void Update()
    {
        GetDriverInput();
        MotorandSteering();
        UpdateAllWheels();
        Breaking();
    }


    private void GetDriverInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        BreakingState = Input.GetKey(KeyCode.Space);
        Fastmode = Input.GetKey(KeyCode.LeftShift);
    }

    private void MotorandSteering()
    {
        CarSteeringAngle = MaxSteeringAngle * HorizontalInput;

        FrontLeftWheelCollider.steerAngle = CarSteeringAngle; // wheel coliders in unity have the property steerAngle which is being set to the cars current steering angle for each wheel.
        FrontRightWheelCollider.steerAngle = CarSteeringAngle;
        CurrentSpeed = (VerticalInput*2) * EngineForce;

        FrontLeftWheelCollider.motorTorque = CurrentSpeed;
        FrontRightWheelCollider.motorTorque = CurrentSpeed;
        RearLeftWheelCollider.motorTorque = CurrentSpeed;
        RearRightWheelCollider.motorTorque = CurrentSpeed;
    }
    private void UpdateAllWheels( )
    {
        updateonewheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
        updateonewheel(FrontRightWheelCollider, FrontRightWheelTransform);
        updateonewheel(RearLeftWheelCollider, RearLeftWheelTransform);
        updateonewheel(RearRightWheelCollider, RearRightWheelTransform);
    }

    private void updateonewheel(WheelCollider Wcollider, Transform Wtransform)
    {
        Quaternion WRotation;
        Vector3 WPosition;

        Wcollider.GetWorldPose(out WPosition, out WRotation);

        Wtransform.rotation = WRotation;
        Wtransform.position = WPosition;

    }

    private void Breaking()
    {
       
        if (BreakingState == true)
        {
            ActiveBreakForce = BrakeForce;
            
        }
        else
        {
            ActiveBreakForce = 0f;
        }
        Usebreak();
    }
    private void Usebreak ()
    {
        FrontLeftWheelCollider.brakeTorque = ActiveBreakForce;
        FrontRightWheelCollider.brakeTorque = ActiveBreakForce;
        RearLeftWheelCollider.brakeTorque = ActiveBreakForce;
        RearRightWheelCollider.brakeTorque = ActiveBreakForce;
    }

    



}
