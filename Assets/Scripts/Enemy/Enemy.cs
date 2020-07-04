using Pathfinding;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private AIPath aiPath;
    private Animator animator;
    private Transform target;

    void Start()
    {
        animator = GetComponent<Animator>();

        aiPath = GetComponent<AIPath>();
        aiPath.canSearch = false;

        target = GetComponent<AIDestinationSetter>().target;

        StartCoroutine(StayIdle());
    }

    private IEnumerator StayIdle()
    {
        float idleTime = Random.Range(1f, 5f);
        yield return  new WaitForSeconds(idleTime);

        aiPath.canSearch = true;
        animator.SetBool("StartChasing", true);
    }


    public void FixedUpdate()
    {
        bool shouldFlip = target.position.x < transform.position.x;
        GetComponent<SpriteRenderer>().flipX = shouldFlip;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayerHit(collision))
        {
            animator.SetBool("Attack", true);
        }
    }

    private bool IsPlayerHit(Collision2D collision)
    {
        return collision.gameObject.CompareTag("Player");
    }

}
