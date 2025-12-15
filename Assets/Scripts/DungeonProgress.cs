using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonProgress : MonoBehaviour
{
    public static DungeonProgress Instance { get; private set; }

    [SerializeField] private int totalDungeons = 3;
    private bool[] completed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        completed = new bool[totalDungeons];
    }

    public void MarkDungeonCompleted(int dungeonIndex)
    {
        if (dungeonIndex < 0 || dungeonIndex >= completed.Length) return;

        if (!completed[dungeonIndex])
        {
            completed[dungeonIndex] = true;
            Debug.Log($"Dungeon {dungeonIndex + 1} completed!");
        }
    }

    public bool AllDungeonsCompleted()
    {
        foreach (bool c in completed)
        {
            if (!c) return false;
        }
        return true;
    }
}
