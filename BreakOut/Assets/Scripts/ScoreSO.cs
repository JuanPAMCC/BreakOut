using UnityEngine;

[CreateAssetMenu(menuName = "ScriptObjects/High Score", fileName = "HighScore")]
public class HighScoreSO : ScriptableObject
{
    public int highScore;

    public void TrySet(int score)
    {
        if (score > highScore) highScore = score;
    }
}