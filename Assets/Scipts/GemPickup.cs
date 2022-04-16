using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CarEngine>() != null)
        {
            CurrencyManager.PropetyInstance.AddGem();
            Destroy(gameObject);
        }
    }
}
