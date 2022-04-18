using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinUIText;
    [SerializeField] TextMeshProUGUI GemUIText; 

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
        CoinUIText.text = m_CoinAmount.ToString();
    }

    public void AddGem()
    {
        m_GemsCollected++;
        GemUIText.text = m_GemsCollected.ToString();
    }
}
