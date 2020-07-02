using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public const int HEAL_AMOUNT = 20;

    private Animator animator;
    private bool canAttack;
    private Sheep attackedSheep;

    private PlayerHealth playerHealth;

    public void Start()
    {
        canAttack = false;
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsSheepHit(collision))
        {
            canAttack = true;
            attackedSheep = collision.collider.GetComponent<Sheep>();
        }
    }

    private static bool IsSheepHit(Collision2D collision)
    {
        return collision.gameObject.CompareTag("FoodTarget");
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        canAttack = false;
        attackedSheep = null;
    }


    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        if (canAttack)
        {
            attackedSheep.Attack();
            playerHealth.Heal(HEAL_AMOUNT);
        }
    }

    public void OnEnable()
    {
        Enemy.OnEnemyAttack += TransitionToAttackedState;
    }

    public void OnDisable()
    {
        Enemy.OnEnemyAttack -= TransitionToAttackedState;
    }

    private void TransitionToAttackedState()
    {
        animator.SetBool("Attacked",true);
        playerHealth.Damage(PlayerHealth.MAX_HEALTH);
    }

}