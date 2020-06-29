using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    public void StopGame()
    {
        //TODO
    }

    public void ResumeGame()
    {
        //TODO
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
