using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CHecks if car hit death conditions, deals with ending game
public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private CarMovement car;


    void Start()
    {
        
    }

    void Update()
    {
        if (car.remainingFuel <= 0)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndGame();
    }

    private void EndGame()
    {
        Debug.Log("dead");
    }
}
