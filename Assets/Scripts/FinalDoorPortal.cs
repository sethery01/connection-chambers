using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoorPortal : MonoBehaviour
{
    [SerializeField] private string endSceneName = "EndScene";

    private Collider doorCollider;

    private void Awake()
    {
        doorCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        UpdateDoorState();
    }

    private void UpdateDoorState()
    {
        if (DungeonProgress.Instance == null)
            return;

        doorCollider.isTrigger = DungeonProgress.Instance.AllDungeonsCompleted();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        SceneManager.LoadScene(endSceneName);
    }
}
