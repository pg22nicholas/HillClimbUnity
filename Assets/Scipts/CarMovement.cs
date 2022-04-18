using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField] WheelJoint2D m_FrontWheel, m_RearWheel;
    [SerializeField] float m_SpeedMultiplier = 1f;
    [SerializeField] private float m_MaxFuel = 1000;
    [SerializeField] private float m_TurnSpeed = 10f;
    [SerializeField] private Transform raycastFrontWheelLoc; 
    [SerializeField] private Transform raycastRearWheelLoc;
    [SerializeField] private float m_RaycastDistance = 1;
    [SerializeField] private float m_FuelLoseSpeed = 1f;
    [SerializeField] private Slider m_UIFuelBar;
    
    private float m_RemainingFuel;
    private Rigidbody2D RigidBody;
    private bool m_IsEnableInput = true;

    float turn = 0;

    private void Start()
    {
        m_RemainingFuel = m_MaxFuel;
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (m_IsEnableInput)
            turn = -Input.GetAxis("Horizontal") * m_SpeedMultiplier;
        else
            turn = 0;

        ConsumeFuel(turn);
        TurnCarInCar();
    }

    // Consume fuel, using turnAxis as multiplier if car is moving
    void ConsumeFuel(float turnAxis)
    {
        float turnMultiplier = turnAxis != 0 ? 1 : .1f;
        m_RemainingFuel -= m_FuelLoseSpeed * Time.deltaTime * turnMultiplier;
        m_UIFuelBar.value = m_RemainingFuel / m_MaxFuel;
        if (m_RemainingFuel <= 0)
            m_RemainingFuel = 0;
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
        if (!Physics2D.Raycast(raycastFrontWheelLoc.position, transform.up * -1 * m_RaycastDistance) ||
            !Physics2D.Raycast(raycastRearWheelLoc.position, transform.up * -1, m_RaycastDistance))
        {
            RigidBody.AddTorque(m_TurnSpeed * turn * -1, ForceMode2D.Force);
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

    public void AddFuel()
    {
        m_RemainingFuel = m_MaxFuel;
    }

    public float remainingFuel
    {
        get { return m_RemainingFuel; }
    }

    public void EnableInput(bool isEnableInput)
    {
        m_IsEnableInput = isEnableInput;
    }
}
