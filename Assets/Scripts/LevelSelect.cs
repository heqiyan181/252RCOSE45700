using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button level2Button;

    void Start()
    {
        int unlock = PlayerPrefs.GetInt("Unlock", 1);
        level2Button.interactable = unlock >= 2;
    }

    public void GoLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void GoLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
