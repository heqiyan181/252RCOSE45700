using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Win : MonoBehaviour
{
    public void Win()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Unlock", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelSelect");
    }
}
