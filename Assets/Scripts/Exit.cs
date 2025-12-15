using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [Tooltip("0 = Dungeon1, 1 = Dungeon2, 2 = Dungeon3")]
    public int dungeonIndex;

    [Tooltip("Scene to return to after finishing a dungeon (e.g., GameScene / Hub)")]
    public string hubSceneName = "GameScene";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (DungeonProgress.Instance != null)
        {
            DungeonProgress.Instance.MarkDungeonCompleted(dungeonIndex);
        }

        SceneManager.LoadScene(hubSceneName);
    }
}
