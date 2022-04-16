using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    [SerializeField] WheelJoint2D m_FrontWheel, m_RearWheel;
    [SerializeField] float m_SpeedMultiplier = 1f;
    [SerializeField] private float m_MaxFuel = 20;
    
    private float m_RemainingFuel;

    float speed = 0;

    void Update()
    {
        speed = -Input.GetAxis("Horizontal") * m_SpeedMultiplier;
    }

    void FixedUpdate()
    {
        JointMotor2D myMotor = new JointMotor2D
        {
            motorSpeed = speed,
            maxMotorTorque = m_RearWheel.motor.maxMotorTorque
        };

        Debug.Log(myMotor.motorSpeed);

        m_FrontWheel.motor = myMotor;
        m_RearWheel.motor = myMotor;
    }
}
