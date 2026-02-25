using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int hp = 3;
    public int score = 0;

    public Pad pad;
    public Ball ball;

    public PersistenceManager persistence;
    public HighScoreSO highScoreData;

    [Header("End Panels")]
    [SerializeField] private GameObject pnEnd;
    [SerializeField] private GameObject pnWin;

    private bool ended;

    void Start()
    {
        ended = false;

        if (pnEnd != null) pnEnd.SetActive(false);
        if (pnWin != null) pnWin.SetActive(false);

        Time.timeScale = 1f;

        if (persistence == null)
            persistence = FindFirstObjectByType<PersistenceManager>();

        if (persistence != null && highScoreData != null)
            persistence.LoadHScore(highScoreData);

        if (pad != null) pad.Rst();
        if (ball != null) ball.Rst();
    }

    public void AddScore(int amount)
    {
        if (ended) return;
        score += amount;
    }

    public int GetHighScore()
    {
        if (highScoreData == null) return 0;
        return highScoreData.highScore;
    }

    public void Win()
    {
        if (ended) return;
        ended = true;

        if (persistence == null)
            persistence = FindFirstObjectByType<PersistenceManager>();

        if (persistence != null && highScoreData != null)
            persistence.SaveHScore(highScoreData, score);

        if (pnWin != null) pnWin.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Lose()
    {
        if (ended) return;

        hp -= 1;

        if (hp <= 0)
        {
            ended = true;

            if (persistence == null)
                persistence = FindFirstObjectByType<PersistenceManager>();

            if (persistence != null && highScoreData != null)
                persistence.SaveHScore(highScoreData, score);

            if (pnEnd != null) pnEnd.SetActive(true);

            Time.timeScale = 0f;
            return;
        }

        if (pad != null) pad.Rst();
        if (ball != null) ball.Rst();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}