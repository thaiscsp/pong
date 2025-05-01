using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int PlayerOneScore { get; set; }
    public int PlayerTwoScore { get; set; }

    public GameObject pauseMenu, winCanvas;
    public TextMeshProUGUI playerOneScoreUI, playerTwoScoreUI, winnerUI;

    void Start()
    {
        Time.timeScale = 1; // Ensures the game will run properly when the scene is loaded
    }

    void Update()
    {
        UpdateScores();
        InterruptGame();
        FinishGame();
    }

    private void UpdateScores()
    {
        playerOneScoreUI.text = PlayerOneScore.ToString();
        playerTwoScoreUI.text = PlayerTwoScore.ToString();
    }

    private void InterruptGame()
    {
        if (Input.GetKeyDown(KeyCode.P)) Pause();
        else if (Input.GetKeyDown(KeyCode.R)) ResetGame();
        else if (Input.GetKeyDown(KeyCode.Escape)) Quit();
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void Quit()
    {
        if (Time.timeScale == 0) SceneManager.LoadScene("Menu");
    }

    private void FinishGame()
    {
        if (PlayerOneScore == 10 || PlayerTwoScore == 10)
        {
            string winner = PlayerOneScore == 10 ? "P1" : PlayerTwoScore == 10 && DataManager.instance.Players == 2 ? "P2" : "CPU";
            winnerUI.text = winner + " wins!";

            float canvasX = winner == "P1" ? 400.88f : 408.8f;
            winCanvas.transform.position = new(canvasX, 130.78f);
            winCanvas.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void ResetGame()
    {
        if (Time.timeScale == 0) SceneManager.LoadScene("Stage");
    }

}
