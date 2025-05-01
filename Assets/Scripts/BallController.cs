using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    SFXManager sfxManager;

    public Vector3 StartPosition { get; private set; }
    public Vector2 Direction { get; set; } = Vector2.left;
    public Vector2 RoundStartDirection { get; set; }

    public float speed;

    bool velocityDoubled;

    void Start()
    {
        StartPosition = transform.position;
        RoundStartDirection = Direction;

        rigidBody = GetComponent<Rigidbody2D>();
        sfxManager = FindFirstObjectByType<SFXManager>();
        
        Move();
    }

    public void Move()
    {
        rigidBody.linearVelocity = Direction * speed * 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sfxManager.PlayClip(sfxManager.hit);
        ChangeVelocity(collision);
    }

    private void ChangeVelocity(Collision2D collision)
    {
        Vector2 ballCenter = GetComponent<Collider2D>().bounds.center;
        Vector2 paddleCenter = collision.collider.bounds.center;
        float distance = ballCenter.y - paddleCenter.y;

        if (!velocityDoubled)
        {
            rigidBody.linearVelocity *= 2;
            velocityDoubled = true;
        }

        rigidBody.linearVelocity = new(rigidBody.linearVelocityX, distance * speed);
    }

    public void ResetBall()
    {
        velocityDoubled = false;
        transform.position = StartPosition;
        RoundStartDirection = -RoundStartDirection;
        Direction = RoundStartDirection;
        Move();
    }

}
