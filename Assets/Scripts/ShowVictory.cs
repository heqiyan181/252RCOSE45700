using UnityEngine;

public class ShowVictory : MonoBehaviour
{
    public GameObject victoryPanel;

    public void Show()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
