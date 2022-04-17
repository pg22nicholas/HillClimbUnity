using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] WheelJoint2D m_FrontWheel, m_RearWheel;
    [SerializeField] float m_SpeedMultiplier = 1f;
    [SerializeField] private float m_MaxFuel = 20;
    [SerializeField] private float m_TurnSpeed = 10f;
    [SerializeField] private Transform raycastFrontWheelLoc; 
    [SerializeField] private Transform raycastRearWheelLoc;
    [SerializeField] private float m_RaycastDistance = 1;
    
    private float m_RemainingFuel;
    private Rigidbody2D RigidBody;

    float turn = 0;

    private void Start()
    {
        m_RemainingFuel = m_MaxFuel;
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        turn = -Input.GetAxis("Horizontal") * m_SpeedMultiplier;

        TurnCarInCar();

    }

    // Turn car by axis controls if in mid-air
    void TurnCarInCar()
    {
        if (Physics2D.Raycast(raycastFrontWheelLoc.position, transform.up * -1 * m_RaycastDistance))
            Debug.DrawRay(raycastFrontWheelLoc.position, transform.up * -1 * m_RaycastDistance, Color.red);
        else
            Debug.DrawRay(raycastFrontWheelLoc.position, transform.up * -1 * m_RaycastDistance, Color.green);

        
        if (Physics2D.Raycast(raycastRearWheelLoc.position, transform.up * -1, m_RaycastDistance))
            Debug.DrawRay(raycastRearWheelLoc.position, transform.up * -1 * m_RaycastDistance, Color.red);
        else
            Debug.DrawRay(raycastRearWheelLoc.position, transform.up * -1 * m_RaycastDistance, Color.green);

        // if the car is not upright on ground, turn
        if (!Physics2D.Raycast(raycastFrontWheelLoc.position, transform.up * -1 * m_RaycastDistance) &&
            !Physics2D.Raycast(raycastRearWheelLoc.position, transform.up * -1, m_RaycastDistance))
        {
            RigidBody.AddTorque(m_TurnSpeed * turn, ForceMode2D.Force);
        }
    }

    void FixedUpdate()
    {
        JointMotor2D myMotor = new JointMotor2D
        {
            motorSpeed = turn,
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
