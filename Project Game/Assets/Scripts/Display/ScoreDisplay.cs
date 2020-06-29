using TMPro;
using UnityEngine;
using static EnemyHealth;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreDisplay : MonoBehaviour
{
    private Animator animator = null;
    private TextMeshProUGUI scoreText = null;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        OnEnemyDeath += UpdateScore;
    }

    private void OnDisable()
    {
        OnEnemyDeath -= UpdateScore;
    }

    private void UpdateScore()
    {
        score += 10;
        scoreText.text = score.ToString();
        animator.SetTrigger("HasScored");
    }
}
