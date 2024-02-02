using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform rightFrontT;
    public Transform leftFrontT;
    public Transform rightBackT;
    public Transform leftBackT;

    public WheelCollider rightFront;
    public WheelCollider leftFront;
    public WheelCollider rightBack;
    public WheelCollider leftBack;



    public float acceleration = 300f;
    public float breakingForce = 200f;
    public float maxTurnDegree;
    public float currentAcc = 0f;
    public float currentBreakForce = 0f;
    public float currentTurnDegree = 0f;

    void FixedUpdate()
    {
        currentAcc = acceleration * Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.Space))
        currentBreakForce = breakingForce;
        else
        currentBreakForce = 0;

        ManageMotor();
        ManageBrake();
        ManageTurn();

        RotateWheels(rightFront,rightFrontT);
        RotateWheels(leftFront,leftFrontT);
        RotateWheels(rightBack,rightBackT);
        RotateWheels(leftBack,leftBackT);



    }
    void ManageMotor(){
        rightFront.motorTorque = currentAcc;
        leftFront.motorTorque = currentAcc;

    }

    void ManageBrake(){
        rightFront.brakeTorque = currentBreakForce;
        leftFront.brakeTorque = currentBreakForce;
        rightBack.brakeTorque = currentBreakForce;
        leftBack.brakeTorque = currentBreakForce;
    }
    void ManageTurn(){
        currentTurnDegree = maxTurnDegree * Input.GetAxis("Horizontal");
        rightFront.steerAngle = currentTurnDegree;
        leftFront.steerAngle = currentTurnDegree;
    }
    void RotateWheels(WheelCollider wheel,Transform T){
        Vector3 pos;
        Quaternion rotation;
        wheel.GetWorldPose(out pos,out rotation);
        T.position = pos;
        T.rotation = rotation;
    }

}
