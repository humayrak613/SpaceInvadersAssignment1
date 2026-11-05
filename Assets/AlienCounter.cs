using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TextMeshProUGUI uiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    public void SetCount(int count)
    {
        score = count;
        uiText.text = "Remaining Aliens: " + count.ToString("#,0");
    }
}
