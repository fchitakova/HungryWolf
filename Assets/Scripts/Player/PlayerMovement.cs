using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 2.5f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector2 movement;
    private ScreenBoundaries screenBoundaries;
 
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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    void FixedUpdate()
    {
        Vector2 currentPosition = rigidBody.position;
        Vector2 newPosition = currentPosition + (movement* moveSpeed *Time.fixedDeltaTime);

        Vector2 newPositionInScreenBoundaries = screenBoundaries.clampNewPositionInScreenBoundaries(newPosition);

        rigidBody.MovePosition(newPositionInScreenBoundaries);

    }

    

}