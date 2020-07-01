using TMPro;
using UnityEngine;
using static InputStorage;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI firstPlayerScoreText = null;

    [SerializeField]
    private TextMeshProUGUI secondPlayerScoreText = null;

    [SerializeField]
    private TextMeshProUGUI finalFirstPlayerScoreText = null;

    [SerializeField]
    private TextMeshProUGUI finalSecondPlayerScoreText = null;

    private GameObject panel = null;

    private void OnEnable()
    {
        Health.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= GameOver;
    }

    private void Start()
    {
        panel = GameObject.FindWithTag("GameOverPanel");
        panel.SetActive(false);
    }

    public void GameOver()
    {
        string firstScore = FirstPlayerName + " - " + firstPlayerScoreText.text;
        string secondScore = SecondPlayerName + " - " + secondPlayerScoreText.text;
        finalFirstPlayerScoreText.text = firstScore;
        finalSecondPlayerScoreText.text = secondScore;
        panel.SetActive(true);
    }
}
