using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int m_CoinAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CarEngine>() != null)
        {
            CurrencyManager.PropetyInstance.AddCoin(m_CoinAmount);
            Destroy(gameObject);
        }
            
        
    }
}
