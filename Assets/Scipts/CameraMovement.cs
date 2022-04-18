using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CarMovement car;
    [SerializeField] private float CameraSlowdown = 100;

    void Start()
    {
        // start camera at car location
        transform.position = new Vector3(car.transform.position.x, car.transform.position.y, transform.position.z);
    }

    private void FixedUpdate() 
    {
        Vector2 deltaVec = (car.transform.position - transform.position) / CameraSlowdown;
        transform.position = new Vector3(transform.position.x + deltaVec.x, transform.position.y + deltaVec.y, transform.position.z);
    }
}
