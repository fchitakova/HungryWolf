using UnityEngine;
using static ScreenBoundaries;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 2.5f;

    [SerializeField]
    internal PlayerController playerController;

    private float playerWidth;
    private float playerHeight;
    private Rigidbody2D rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initPlayerSize();
    }

    void initPlayerSize()
    {
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 currentPosition = rigidBody.position;
        Vector2 newPosition = currentPosition + (playerController.movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 newPositionInScreenBoundaries = clampObjectPositionInScreenBoundaries(playerWidth, playerHeight, newPosition);
       
        rigidBody.MovePosition(newPositionInScreenBoundaries);
    }

}
