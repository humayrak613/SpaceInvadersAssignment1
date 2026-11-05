using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [Header("Inscribed")]
    [Tooltip("Assign Heart1, Heart2, Heart3 in order in the Inspector.")]
    public Image[] hearts;

    void Start()
    {
        // Subscribe to the manager. If it's not there yet, warn loudly.
        if (LivesManager.Instance == null)
        {
            Debug.LogError("LivesUI: no LivesManager in scene!");
            return;
        }
        LivesManager.Instance.OnLivesChanged += Refresh;
        // Draw initial state immediately.
        Refresh(LivesManager.Instance.Lives);
    }

    void OnDestroy()
    {
        // Always unsubscribe - prevents a dangling callback on scene unload.
        if (LivesManager.Instance != null)
            LivesManager.Instance.OnLivesChanged -= Refresh;
    }

    void Refresh(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
            hearts[i].enabled = i < lives;
    }
}