using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneChange : MonoBehaviour
{
    public GameObject pause;

    public void LoadScene()
    {
        SceneManager.LoadScene("_Nivel1");
    }

    public void Menu()
    {   
        SceneManager.LoadScene("Menu"); 
    }

    public void Restart()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
