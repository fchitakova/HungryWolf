using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 2.5f;
    private Vector2 movement;
    private ScreenBoundaries screenBoundaries;

    private Rigidbody2D rigidBody;
    private Animator animator;
 
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        instantiateScreenBoundaries();
    }

    void instantiateScreenBoundaries()
    {
        float playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        screenBoundaries = new ScreenBoundaries(playerWidth, playerHeight);
     }

    void Update()
    {
        GetMovementInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void GetMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Attack()
    {
        //play an attack animation
        //detect enemies in range of attack
        //damage them
    }

    void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        Vector2 currentPosition = rigidBody.position;
        Vector2 newPosition = currentPosition + (movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 newPositionInScreenBoundaries = screenBoundaries.clampNewPositionInScreenBoundaries(newPosition);
        rigidBody.MovePosition(newPositionInScreenBoundaries);
    }


}