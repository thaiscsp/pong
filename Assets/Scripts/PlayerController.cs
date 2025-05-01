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
        if (playerType != PlayerType.CPU) rigidBody.linearVelocity = direction * speed;
        else
        {
            Vector3 target = new(transform.position.x, ballController.transform.position.y, transform.position.z);
            float distance = Vector3.Distance(transform.position, target); // To avoid "jiggling/exact match" behavior

            if (distance > 0.65f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime * 0.9f);
            }

            //float yDistance = ballController.transform.position.y - transform.position.y;
            //lastDirection = direction;
            //direction = yDistance > 0.75f ? Vector2.up : Vector2.down;
            //rigidBody.linearVelocity = direction * speed;

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
