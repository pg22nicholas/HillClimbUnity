using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CHecks if car hit death conditions, deals with ending game
public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private CarMovement car;
    [SerializeField] private GameObject LoseScreen;


    void Start()
    {
        LoseScreen.SetActive(false);
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
        if (collision.tag == "Floor")
            EndGame();
    }

    private void EndGame()
    {
        LoseScreen.SetActive(true);
        car.EnableInput(false);
    }
}
