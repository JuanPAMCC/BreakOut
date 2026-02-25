using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private OptionsSO options;

    [Header("UI")]
    [SerializeField] private TMP_Dropdown levelDropdown;
    [SerializeField] private TMP_Dropdown difficultyDropdown;

    [Header("Scenes (must be in Build Settings)")]
    [SerializeField] private List<string> levelSceneNames = new List<string> { "_Nivel1", "_Nivel2", "_Nivel3" };

    private int selectedLevelIndex = 0;

    private void Awake()
    {
        SetupLevelDropdown();
        SetupDifficultyDropdown();

        if (levelDropdown != null)
        {
            levelDropdown.onValueChanged.AddListener(OnLevelChanged);
            OnLevelChanged(levelDropdown.value);
        }

        if (difficultyDropdown != null)
        {
            difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
            OnDifficultyChanged(difficultyDropdown.value);
        }
    }

    private void SetupLevelDropdown()
    {
        if (levelDropdown == null) return;

        levelDropdown.ClearOptions();
        levelDropdown.AddOptions(new List<string> { "Nivel 1", "Nivel 2", "Nivel 3" });
        levelDropdown.value = 0;
        levelDropdown.RefreshShownValue();
    }

    private void SetupDifficultyDropdown()
    {
        if (difficultyDropdown == null) return;

        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(new List<string> { "Easy", "Normal", "Hard" });
        difficultyDropdown.value = 1;
        difficultyDropdown.RefreshShownValue();
    }

    public void OnLevelChanged(int index)
    {
        selectedLevelIndex = Mathf.Clamp(index, 0, Mathf.Max(0, levelSceneNames.Count - 1));
    }

    public void OnDifficultyChanged(int index)
    {
        if (options == null) return;

        if (index == 0) options.difficulty = Difficulty.Easy;
        else if (index == 2) options.difficulty = Difficulty.Hard;
        else options.difficulty = Difficulty.Normal;
    }

    public void StartGame()
    {
        if (levelSceneNames == null || levelSceneNames.Count == 0) return;

        int idx = Mathf.Clamp(selectedLevelIndex, 0, levelSceneNames.Count - 1);
        SceneManager.LoadScene(levelSceneNames[idx]);
    }
}