using UnityEngine;
using TMPro;
using System;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinCounterText;
    private int CoinAmount;
    public static event Action OnAddCoin; 

    void OnEnable()
    {
        coin.OnCollectCoin += AddCoin;      
    }

    void OnDisable()
    {
        coin.OnCollectCoin -= AddCoin;      
    }
    public void UpdateCoinCounter()
    {

    }

    public void AddCoin(int c)
    {
        CoinAmount += c;
        CoinCounterText.text = CoinAmount.ToString("0");
    }
}
