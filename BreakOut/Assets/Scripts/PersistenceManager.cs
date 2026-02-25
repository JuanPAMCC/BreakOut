using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    private const string KeyPrefix = "highscore_";

    private static PersistenceManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int LoadHScore(HighScoreSO data)
    {
        if (data == null) return 0;
        data.highScore = PlayerPrefs.GetInt(KeyPrefix + data.name, 0);
        return data.highScore;
    }

    public void SaveHScore(HighScoreSO data, int score)
    {
        if (data == null) return;
        data.TrySet(score);
        PlayerPrefs.SetInt(KeyPrefix + data.name, data.highScore);
        PlayerPrefs.Save();
    }
}