using System;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static LivesManager Instance { get; private set; }

    [Header("Inscribed")]
    public int startingLives = 3;

    [Header("Dynamic")]
    public int Lives { get; private set; }

    // Fires every time lives change. Parameter = new life count.
    public event Action<int> OnLivesChanged;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        Lives = startingLives;
        OnLivesChanged?.Invoke(Lives);
    }

    public void LoseLife()
    {
        if (Lives <= 0) return;  
        Lives--;
        OnLivesChanged?.Invoke(Lives);
        Debug.Log($"Life lost. Lives remaining: {Lives}");

        // lose condition
        if (Lives == 0)
        {
            GameManager.Instance.EndGame(false);
        }
    }
}