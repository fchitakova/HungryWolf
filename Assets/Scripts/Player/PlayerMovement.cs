using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 2.5f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector2 movement;
    private Vector2 horizontalScreenBoundaries;
    private Vector2 verticalScreenBoundaries;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        calculateScreenBoundaries();
    }

    void calculateScreenBoundaries()
    {
        float cameraZposition = Camera.main.transform.position.z;
        Vector2 screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraZposition));
        float playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        horizontalScreenBoundaries = new Vector2((-screenBoundaries.x) + playerWidth, screenBoundaries.x - playerWidth);
        verticalScreenBoundaries = new Vector2((-screenBoundaries.y)+ playerHeight, screenBoundaries.y - playerHeight);
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

        Vector2 newPositionInScreenBoundaries = clampNewPositionInScreenBoundaries(newPosition);

        rigidBody.MovePosition(newPositionInScreenBoundaries);

    }

    Vector2 clampNewPositionInScreenBoundaries(Vector2 newPosition)
    {
        Vector2 newPositionInScreenBoundaries;
        newPositionInScreenBoundaries.x = Mathf.Clamp(newPosition.x, horizontalScreenBoundaries.x, horizontalScreenBoundaries.y);
        newPositionInScreenBoundaries.y = Mathf.Clamp(newPosition.y, verticalScreenBoundaries.x, verticalScreenBoundaries.y);
        return newPositionInScreenBoundaries;
    }

}