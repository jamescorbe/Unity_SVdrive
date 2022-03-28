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
    public Rigidbody rb;
    public float downforce = 300.5f;

    [SerializeField] public float EngineForce;
    [SerializeField] public float CurrentSpeed;
    [SerializeField] private float BrakeForce;


    [SerializeField] public BoxCollider carbody;
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
        CurrentSpeed = (VerticalInput) * EngineForce;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, downforce, ForceMode.Impulse); // to Improve controll of the car a constant downforce is applied
        FrontLeftWheelCollider.motorTorque = CurrentSpeed; // updating the motorTorque on the wheel colliders to make the car move when w or s is pressed.
        FrontRightWheelCollider.motorTorque = CurrentSpeed;
        RearLeftWheelCollider.motorTorque = CurrentSpeed*2;
        RearRightWheelCollider.motorTorque = CurrentSpeed*2;
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
        Quaternion WRotation; // wheel rotation
        Vector3 WPosition; // wheel position

        Wcollider.GetWorldPose(out WPosition, out WRotation); //getting the position and rotation of the current wheel 

        Wtransform.rotation = WRotation;// updating the transform rotation and then position in the scene.
        Wtransform.position = WPosition;

    }

    private void Breaking() // when space is pressed the breaking function is called setting ActiveBreakForce
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
    private void Usebreak () // once the breaking state is checked and ActiveBreakForce is set it is applied to the wheel coliders with the .breakTorque function.
    {
        FrontLeftWheelCollider.brakeTorque = ActiveBreakForce;
        FrontRightWheelCollider.brakeTorque = ActiveBreakForce;
        RearLeftWheelCollider.brakeTorque = ActiveBreakForce;
        RearRightWheelCollider.brakeTorque = ActiveBreakForce;
    }

    



}
