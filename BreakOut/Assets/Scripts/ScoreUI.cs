using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private GM gm;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text livesText;

    [SerializeField] private OptionsSO options;
    [SerializeField] private TMP_Text difficultyText;

    private void Awake()
    {
        if (gm == null)
            gm = FindFirstObjectByType<GM>();
    }

    private void Update()
    {
        if (gm == null) return;

        if (scoreText != null)
            scoreText.text = "Score: " + gm.score;

        if (highScoreText != null)
            highScoreText.text = "Highscore: " + gm.GetHighScore();

        if (livesText != null)
            livesText.text = "Lives: " + gm.hp;

        if (options == null || difficultyText == null) return;
        difficultyText.text = "Difficulty: " + options.difficulty.ToString();
    }
}