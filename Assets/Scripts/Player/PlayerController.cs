using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 2.5f;
    private Vector2 movement;
    private ScreenBoundaries screenBoundaries;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


 
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag( "FoodTarget"))
              Debug.Log("Collisiion!");
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
        animator.SetTrigger("Attack");
        Collider2D[]hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit : " + enemy.name);
        }
        
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