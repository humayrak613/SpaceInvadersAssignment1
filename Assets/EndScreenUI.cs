using UnityEngine;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        if (GameManager.Instance.PlayerWon)
        {
            resultText.text = "YOU WIN!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "GAME OVER";
            resultText.color = Color.red;
        }
    }
}