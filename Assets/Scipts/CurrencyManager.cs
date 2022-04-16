using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    private int m_CoinAmount = 0;
    private int m_GemsCollected = 0;

    private static CurrencyManager s_PropertyInstance;

    public static CurrencyManager PropetyInstance {
        get { return s_PropertyInstance; } 
    }

    private void Awake()
    {
        if (s_PropertyInstance != null && s_PropertyInstance != this)
        {
            Destroy(this);
            return;
        }
        s_PropertyInstance = this;
    }

    public void AddCoin(int CoinAmount)
    {
        m_CoinAmount += CoinAmount;
        Debug.Log(m_CoinAmount + " Coins");
    }

    public void AddGem()
    {
        m_GemsCollected++;
        Debug.Log(m_GemsCollected + " Gems");
    }
}
