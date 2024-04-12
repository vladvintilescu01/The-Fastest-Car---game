using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarControl : MonoBehaviour
{
    public WheelCollider frontLeftWheelCol;
    public WheelCollider frontRightWheelCol;
    public WheelCollider rearLeftWheelCol;
    public WheelCollider rearRightWheelCol;

    public Transform frontLeftWheelPos;
    public Transform frontRightWheelPos;
    public Transform rearLeftWheelPos;
    public Transform rearRightWheelPos;

    float _horizontal;
    float _vertical;
    float _steeringAngle;
    float damage_Steering;

    public float steeringAngle = 30f;
    public float accelerationSpeed = 10000f;
    public float brakeTorque = 5000f;

    public float initial_steeringAngle;
    public float initial_accelerationSpeed;
    public float initial_brakeTorque;

    public Slider hpBar;
    
    void Start()
    {
        initial_steeringAngle = steeringAngle;
        initial_accelerationSpeed = accelerationSpeed;
        initial_brakeTorque = brakeTorque;
        /* Initial parameters of car */
    }

    // Update is called once per frame
     void Update()
    {
        //input from player 
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        //steering
        frontLeftWheelCol.steerAngle = _horizontal * steeringAngle;
        frontRightWheelCol.steerAngle = _horizontal * steeringAngle;
    
        //accerlerate
        frontLeftWheelCol.motorTorque = _vertical * accelerationSpeed;
        frontRightWheelCol.motorTorque = _vertical * accelerationSpeed;
     
        //Rotion Wheel
        WheelTransform(frontLeftWheelCol, frontLeftWheelPos);
        WheelTransform(frontRightWheelCol, frontRightWheelPos);
        WheelTransform(rearLeftWheelCol, rearLeftWheelPos);
        WheelTransform(rearRightWheelCol, rearRightWheelPos);

        //Brake
        if(Input.GetKeyDown(KeyCode.Space))
        {
            frontLeftWheelCol.brakeTorque = brakeTorque;
            frontRightWheelCol.brakeTorque = brakeTorque;
            rearLeftWheelCol.brakeTorque = brakeTorque;
            rearRightWheelCol.brakeTorque = brakeTorque;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            frontLeftWheelCol.brakeTorque = 0f;
            frontRightWheelCol.brakeTorque = 0f;
            rearLeftWheelCol.brakeTorque = 0f;
            rearRightWheelCol.brakeTorque = 0f;
        }
    }
       //wheel rotation
    void WheelTransform(WheelCollider _collider, Transform _transform)
    {
        Vector3 _position = _transform.position;
        Quaternion _quaternion = _transform.rotation;

        _collider.GetWorldPose(out _position, out _quaternion);

        _transform.position = _position;
        _transform.rotation = _quaternion;
    }

    void OnTriggerEnter(Collider other)
    {  
       if (other.CompareTag("Repair"))
        {
            steeringAngle = initial_steeringAngle;
            accelerationSpeed = initial_accelerationSpeed;
            brakeTorque = initial_brakeTorque;
            hpBar.value = 40;
            /* Reset values when the player wants to repair */
        }

    }
}
