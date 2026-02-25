using UnityEngine;

public enum Difficulty
{
    Easy = 0,
    Normal = 1,
    Hard = 2
}

[CreateAssetMenu(menuName = "ScriptObjects/Options", fileName = "OptionsData")]
public class OptionsSO : ScriptableObject
{
    public Difficulty difficulty = Difficulty.Normal;
}