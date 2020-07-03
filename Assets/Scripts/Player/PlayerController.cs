using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public const int MOVEMENT_HEALTH_DAMAGE = 5;
    public const int HEAL_AMOUNT = 20;

    [SerializeField]
    internal PlayerInput playerInput;

    [SerializeField]
    internal PlayerMovement playerMovement;

    [SerializeField]
    internal PlayerCollision playerCollision;

    internal Vector2 movement;
    private Animator animator;

    private PlayerHealth playerHealth;

    public void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }



    void Update()
    {
        HandlePlayerCollisions();
        HandlePlayerMovement();
    }

    private void HandlePlayerCollisions()
    {
        if (isCollidedWithSheep())
        {
            Attack(playerCollision.collisionInvolvedSheep);
        }

        if (isCollidedWithEnemy())
        {
            TransitionToAttackedState();
        }
    }

    private bool isCollidedWithSheep()
    {
        return playerInput.isAttackPressed && playerCollision.collidedWithSheep;
    }

    private bool isCollidedWithEnemy()
    {
        return playerCollision.collidedWithEnemy;
    }

    private void Attack(Sheep attackedSheep)
    {
        animator.SetTrigger("Attack");
        attackedSheep.Attack();
        playerHealth.Heal(HEAL_AMOUNT);
    }

    private void TransitionToAttackedState()
    {
        animator.SetBool("Attacked", true);
        playerHealth.Damage(PlayerHealth.MAX_HEALTH);
    }

    private void HandlePlayerMovement()
    {
        movement = playerInput.movement;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        AffectPlayerHealthFromMovement();
    }

    private void AffectPlayerHealthFromMovement()
    {
        if (playerInput.moveAttempted)
        {
            playerHealth.Damage(MOVEMENT_HEALTH_DAMAGE);
           
            if (IsPlayerExhausted())
            {
                TransitionToDeadState();
            }
        }
    }
    private bool IsPlayerExhausted()
    {
        return !playerHealth.IsPositive() && animator.GetBool("Attacked") == false;
    }

    private void TransitionToDeadState()
    {
        animator.SetTrigger("Dead");
    }


}