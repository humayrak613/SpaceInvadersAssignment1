using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    public void GoToMenu()
    {
        GameManager.Instance.ReturnToMenu();
    }
}