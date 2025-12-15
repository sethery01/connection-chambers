using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPortal : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private int dungeonIndex;

    private Collider doorCollider;

    private void Awake()
    {
        doorCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        bool completed = DungeonProgress.Instance != null &&
                         DungeonProgress.Instance.IsDungeonCompleted(dungeonIndex);

        doorCollider.isTrigger = !completed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (DungeonProgress.Instance != null &&
            DungeonProgress.Instance.IsDungeonCompleted(dungeonIndex))
            return;

        SceneManager.LoadScene(sceneToLoad);
    }
}
