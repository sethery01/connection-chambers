using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    [Tooltip("Scene to load after going through the final door")]
    public string finalSceneName = "EndScene";

    public GameObject lockedVisual;
    public GameObject openVisual; 

    private bool isUnlocked = false;

    private void Start()
    {
        UpdateDoorState();
    }

    private void UpdateDoorState()
    {
        if (DungeonProgress.Instance != null &&
            DungeonProgress.Instance.AllDungeonsCompleted())
        {
            isUnlocked = true;
            if (lockedVisual) lockedVisual.SetActive(false);
            if (openVisual) openVisual.SetActive(true);
        }
        else
        {
            isUnlocked = false;
            if (lockedVisual) lockedVisual.SetActive(true);
            if (openVisual) openVisual.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!isUnlocked)
        {
            Debug.Log("Door is locked. Clear all three dungeons first.");
            return;
        }

        SceneManager.LoadScene(finalSceneName);
    }
}
