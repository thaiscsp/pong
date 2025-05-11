using UnityEngine;

public class ScoreAreaController : MonoBehaviour
{
    BallController ballController;
    GameManager gameManager;
    SFXManager sfxManager;
    public enum ScoreAreaType { playerOne, playerTwo }
    public ScoreAreaType scoreAreaType;

    void Start()
    {
        ballController = FindFirstObjectByType<BallController>();
        gameManager = FindFirstObjectByType<GameManager>();
        sfxManager = FindFirstObjectByType<SFXManager>();
    }

    private void IncreaseScore()
    {
        sfxManager.PlayClip(sfxManager.score);

        if (scoreAreaType == ScoreAreaType.playerOne) gameManager.PlayerOneScore++;
        else gameManager.PlayerTwoScore++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            IncreaseScore();
            ballController.ResetBall();
        }
    }

}
