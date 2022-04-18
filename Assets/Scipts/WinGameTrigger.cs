using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameTrigger : MonoBehaviour
{

    [SerializeField] private CarMovement car;
    [SerializeField] private GameObject WinScreen;

    private void Start()
    {
        WinScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinScreen.SetActive(true);
        car.EnableInput(false);
    }
}
