using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Win : MonoBehaviour
{
    public void Win()
    {
        PlayerPrefs.SetInt("Unlock", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelSelect");
    }
}
