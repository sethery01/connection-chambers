using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Update()
    {
        if (CoinManager.Instance != null)
        {
            coinText.text = $"Coins: {CoinManager.Instance.GetCurrent()}/{CoinManager.Instance.GetGoal()}";
        }
    }
}
