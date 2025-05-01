using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Update()
    {
        StartGame();
    }

    private void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartOnePlayerGame();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            StartTwoPlayerGame();
        }
    }

    public void StartOnePlayerGame()
    {
        DataManager.instance.Players = 1;
        SceneManager.LoadScene("Stage");
    }

    public void StartTwoPlayerGame()
    {
        DataManager.instance.Players = 2;
        SceneManager.LoadScene("Stage");
    }

}
