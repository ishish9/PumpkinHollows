using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinDisplay;
    [SerializeField] private TextMeshProUGUI SeedDisplay;
    [SerializeField] private GameObject seedDisplay;
    [SerializeField] private GameObject coinDisplay;
    public delegate void ScoreEvent(int s);
    public static event ScoreEvent OnScoreChange;
    private int coins = 0;
    private int seeds = 0;


    void OnEnable()
    {
        CoinTrigger.OnScore += CoinAdd;
        Seed.OnScore += SeedAdd;
    }

    void OnDisable()
    {
        CoinTrigger.OnScore -= CoinAdd;
        Seed.OnScore -= SeedAdd;
    }
    public void CoinAdd(int AddAmount)
    {
        coinDisplay.SetActive(true);
        coins += AddAmount;
        CoinDisplay.text = coins.ToString();
        StartCoroutine(updateCoinScore());

        IEnumerator updateCoinScore()
        {
            yield return new WaitForSeconds(4);
            coinDisplay.SetActive(false);     
        }
    }

    public void SeedAdd(int AddAmount)
    {
        seedDisplay.SetActive(true);
        seeds += AddAmount;
        SeedDisplay.text = seeds.ToString();
        StartCoroutine(updateSeedScore());

        IEnumerator updateSeedScore()
        {
            yield return new WaitForSeconds(4);
            seedDisplay.SetActive(false);
        }    
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
