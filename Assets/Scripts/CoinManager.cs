using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] private int coinsToReturn = 4;
    [SerializeField] private string gameSceneName = "GameScene";

    private int currentCoins = 0;

    private void Awake()
    {
        // Simple singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddCoin()
    {
        currentCoins++;
        Debug.Log($"Coin collected: {currentCoins}/{coinsToReturn}");

        if (currentCoins >= coinsToReturn)
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
