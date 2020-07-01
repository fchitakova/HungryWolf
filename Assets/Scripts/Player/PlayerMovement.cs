using UnityEngine;
using static ScreenBoundaries;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.5f;
    private Vector2 movement;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private float playerWidth;
    private float playerHeight;

    private PlayerHealth playerHealth;


    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initPlayerSize();
    }

    void initPlayerSize()
    {
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void Update()
    {
        GetMovementInput();
    }


    private void GetMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        Vector2 currentPosition = rigidBody.position;
        Vector2 newPosition = currentPosition + (movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 newPositionInScreenBoundaries = clampObjectPositionInScreenBoundaries(playerWidth, playerHeight, newPosition);
        rigidBody.MovePosition(newPositionInScreenBoundaries);

        playerHealth.Damage(1);
    }

}
