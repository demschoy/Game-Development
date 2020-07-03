using System;
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

    public void GameOver()
    {
        GameObject panel = GameObject.FindGameObjectWithTag("GameOverPanel");
        panel.SetActive(true);
    }

    private void OnEnable()
    {
        Health.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= GameOver;
    }
}
