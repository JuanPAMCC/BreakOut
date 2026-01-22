using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GM : MonoBehaviour
{
    public int hp = 3;
    public Pad pad;
    public Ball ball;

    void Start()
    {
        if (pad != null) pad.Rst();
        if (ball != null) ball.Rst();
        Debug.Log("vidas " + hp);
    }

    public void Lose()
    {
        hp -= 1;
        Debug.Log("vida menos " + hp);

        if (hp <= 0)
        {
            Debug.Log("Intenta de nuevo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (pad != null) pad.Rst();
        if (ball != null) ball.Rst();
    }
}
