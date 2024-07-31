using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private AudioClips audioClip;
    [SerializeField] private TextMeshProUGUI CoinDisplay;
    [SerializeField] private TextMeshProUGUI SeedDisplay;
    [SerializeField] private TextMeshProUGUI coinDisplayInventory;
    [SerializeField] private TextMeshProUGUI seedDisplayInventory;
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
        CoinMultiple.OnScore += CoinMultipleAdd;
    }

    void OnDisable()
    {
        CoinTrigger.OnScore -= CoinAdd;
        Seed.OnScore -= SeedAdd;
        CoinMultiple.OnScore -= CoinMultipleAdd;
    }
    public void CoinAdd(int AddAmount)
    {
        int waitDisplay = 4;
        AudioManager.instance.PlaySound(audioClip.CollectCoin);
        coinDisplay.SetActive(true);
        
        StartCoroutine(updateCoinScore());

        IEnumerator updateCoinScore()
        {
            yield return new WaitForSeconds(.2f);
            coins += AddAmount;
            CoinDisplay.text = coins.ToString();
            coinDisplayInventory.text = coins.ToString();
            yield return new WaitForSeconds(waitDisplay);
            coinDisplay.SetActive(false);
            StopCoroutine(updateCoinScore());
        }
    }
    public void CoinMultipleAdd(int AddAmount)
    {
        coinDisplay.SetActive(true);
        //coins += AddAmount;

        StartCoroutine(multiScoreSound());

        IEnumerator multiScoreSound()
        {
            for (int i = 0; i < AddAmount; i++)
            {
                AudioManager.instance.PlaySound(audioClip.CollectCoin);
                coins++;
                CoinDisplay.text = coins.ToString();
                coinDisplayInventory.text = coins.ToString();

                yield return new WaitForSeconds(.01f);
            }
        }

        StartCoroutine(updateCoinScore());

        IEnumerator updateCoinScore()
        {
            yield return new WaitForSeconds(4);
            coinDisplay.SetActive(false);
        }
    }

    public void SeedAdd(int AddAmount)
    {
        AudioManager.instance.PlaySound(audioClip.CollectSeed);
        seedDisplay.SetActive(true);
        seeds += AddAmount;
        SeedDisplay.text = seeds.ToString();
        seedDisplayInventory.text = seeds.ToString();
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
        coinDisplayInventory.text = coins.ToString();
    }

    public int GetCoinScore()
    {
        return coins;
    }
}
