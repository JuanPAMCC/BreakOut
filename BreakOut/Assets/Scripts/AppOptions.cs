using UnityEngine;

public class AppOptions : MonoBehaviour
{
    public OptionsSO options;

    private void Awake()
    {
        if (options == null) return;

        var balls = FindObjectsByType<Ball>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].options = options;
        }

        var blocks = FindObjectsByType<Bloq>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].options = options;
        }
    }
}