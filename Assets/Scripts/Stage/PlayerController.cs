using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    BallController ballController;
    Rigidbody2D rigidBody;
    Vector2 direction, lastDirection;

    public enum PlayerType { PlayerOne, PlayerTwo, CPU }
    public PlayerType playerType;
    public float speed;

    void Start()
    {
        ballController = FindFirstObjectByType<BallController>();
        rigidBody = GetComponent<Rigidbody2D>();
        ChangePlayerType();
    }

    void Update()
    {
        MoveVertically();
    }

    private void MoveVertically()
    {
        if (playerType != PlayerType.CPU)
        {
            rigidBody.linearVelocity = direction * speed;
        }
        else
        {
            Vector3 target = new(transform.position.x, ballController.transform.position.y, transform.position.z);
            float distance = Vector3.Distance(transform.position, target);

            if ((distance > 0.3f && distance < 0.35f) || distance > 0.7f) // To avoid "jiggling/exact match" behavior
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime * 0.9f);
            }
        } 
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void ChangePlayerType()
    {
        if (playerType == PlayerType.PlayerTwo && DataManager.instance.Players == 1) playerType = PlayerType.CPU;
    }

}
