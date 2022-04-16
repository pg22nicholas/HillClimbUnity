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

    private void Start()
    {
        m_RemainingFuel = m_MaxFuel;
    }

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

        m_FrontWheel.motor = myMotor;
        m_RearWheel.motor = myMotor;
    }

    public void AddFuel(float fuelAmount)
    {
        m_RemainingFuel += Mathf.Min(m_MaxFuel - m_RemainingFuel, fuelAmount);
        Debug.Log(m_RemainingFuel);
    }
}
