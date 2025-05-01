using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        InterruptGame();
    }

    private void InterruptGame()
    {
        if (Input.GetKeyDown(KeyCode.P)) Pause();
        else if (Input.GetKeyDown(KeyCode.Escape)) Quit();
    }

    public void Pause()
    {
        if (Time.timeScale == 1) Time.timeScale = 0;
    }

    public void Quit()
    {
        if (Time.timeScale == 0) SceneManager.LoadScene("Menu");
    }

}
