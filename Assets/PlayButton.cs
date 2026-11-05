using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        // Tell the surviving GameManager to start the game
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }
        else
        {
            // Fallback just in case the GameManager didn't spawn for some reason
            SceneManager.LoadScene("GameScreen");
        }
    }
}