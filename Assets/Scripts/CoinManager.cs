using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] private int coinsToReturn = 4;
    [SerializeField] private string hubSceneName = "GameScene";
    [SerializeField] private int dungeonIndex = -1; // 0 = Dungeon1, 1 = Dungeon2, 2 = Dungeon3

    private int currentCoins = 0;

    private void Awake()
    {
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
            if (dungeonIndex >= 0 && DungeonProgress.Instance != null)
            {
                DungeonProgress.Instance.MarkDungeonCompleted(dungeonIndex);
            }

            SceneManager.LoadScene(hubSceneName);
        }
    }

    public int GetCurrent() => currentCoins;
    public int GetGoal() => coinsToReturn;
}
