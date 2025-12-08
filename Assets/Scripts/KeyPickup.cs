using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private string hubSceneName = "GameScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up key in Dungeon1");

            SceneManager.LoadScene(hubSceneName);
        }
    }
}
