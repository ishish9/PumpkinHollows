using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinDisplay;
    public delegate void ScoreEvent(int s);
    public static event ScoreEvent OnScoreChange;
    private int coins = 0;

    void OnEnable()
    {
        CoinTrigger.OnScore += CoinAdd;
    }

    void OnDisable()
    {
        CoinTrigger.OnScore -= CoinAdd;
    }
    public void CoinAdd(int AddAmount)
    {
        coins += AddAmount;
        CoinDisplay.text = coins.ToString();
    }

    public void ResetCoinScore()
    {
        coins = 0;
        CoinDisplay.text = coins.ToString();
    }

    public int GetCoinScore()
    {
        return coins;
    }
}
