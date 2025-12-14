using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoin();
            }

            Destroy(gameObject);
        }
    }
}
