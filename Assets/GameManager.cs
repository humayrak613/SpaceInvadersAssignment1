using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    // If something asks for Instance and it doesn't exist, it spawns itself!
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Look for one in the scene
                _instance = FindFirstObjectByType<GameManager>();

                // If it still doesn't exist, create it on the fly
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public bool PlayerWon { get; private set; } = false;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void EndGame(bool won)
    {
        PlayerWon = won;
        SceneManager.LoadScene("EndScreen");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}