using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play button clicked!");  // This helps us debug
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Debug.Log("Exit button clicked!");  // This helps us debug
        Application.Quit();
    }
}