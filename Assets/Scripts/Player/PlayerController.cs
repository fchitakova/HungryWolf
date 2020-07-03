﻿using System;
using UnityEngine;

[Serializable]
public class PlayerController : MonoBehaviour
{
    public const int MOVEMENT_HEALTH_DAMAGE = 5;
    public const int HEAL_AMOUNT = 20;

    private const string EAT_SHEEP_SOUND = "EatSheep";
    private const string GAME_OVER_SOUND = "GameOver";
    private const string ATTACK = "Attack";
    private const string ATTACKED = "Attacked";

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
            FindObjectOfType<AudioManager>().Play(EAT_SHEEP_SOUND);
        }

        if (isCollidedWithEnemy())
        {
            TransitionToAttackedState();
            FindObjectOfType<AudioManager>().Play(GAME_OVER_SOUND);
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
        animator.SetTrigger(ATTACK);
        attackedSheep.Attack();
        playerHealth.Heal(HEAL_AMOUNT);
    }

    private void TransitionToAttackedState()
    {
        animator.SetBool(ATTACKED, true);
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
        return !playerHealth.IsPositive() && animator.GetBool(ATTACKED) == false;
    }

    private void TransitionToDeadState()
    {
        animator.SetTrigger("Dead");
    }


}