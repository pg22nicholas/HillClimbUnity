using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour
{

    [SerializeField] private float m_DurationMoving = 1;
    [SerializeField] private float m_MoveAmount = 1;

    private bool m_BMovingUp = true;
    private Vector2 m_OriginalPosition;
    private float m_BottomYPos;
    private float m_TopYPos;

    private void Start()
    {
        m_OriginalPosition = transform.position;
        m_BottomYPos = m_OriginalPosition.y - m_MoveAmount;
        m_TopYPos = m_OriginalPosition.y + m_MoveAmount;
        StartCoroutine(LerpMovement());
    }

    private void FixedUpdate()
    {
    }

    IEnumerator LerpMovement()
    {
        // start between top and bottom y positions
        float currTime = m_DurationMoving / 2;
        while (true)
        {
            currTime += Time.deltaTime;
            float val = Mathf.Lerp(m_BMovingUp ? m_BottomYPos : m_TopYPos,
                                    m_BMovingUp ? m_TopYPos : m_BottomYPos,
                                    currTime / m_DurationMoving);

            transform.position = new Vector3(m_OriginalPosition.x, val);
            
            if (currTime > m_DurationMoving)
            {
                currTime = 0;
                m_BMovingUp = !m_BMovingUp;
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CarMovement engine = collision.GetComponent<CarMovement>();
        if (engine != null)
        {
            engine.AddFuel();
            StopCoroutine(LerpMovement());
            Destroy(gameObject);
        }
    }
}
