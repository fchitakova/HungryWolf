using Pathfinding;
using System;
using System.Collections;
using UnityEngine;
using static ScreenBoundaries;
using Random = UnityEngine.Random;

public class Sheep : MonoBehaviour
{
    Transform target;
    Rigidbody2D rigidBody;
    Animator animator;

    AIPath aiPath;
    AIDestinationSetter destinationSetter;

    public static event Action OnSheepAttacked;


    public void Start()
    {
        target = new GameObject().transform;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
       
        StartCoroutine(Wander());
    }

    private IEnumerator Wander()
    {
        while (true)
        {
            target.position = getRandomFreePositionInScreenBoundaries();
            destinationSetter.target = target;

            while (!isTargetReached())
            {
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 5f));
        }
    }

    private bool isTargetReached()
    {
        Vector2 currentPosition = rigidBody.position;
        Vector2 targetPosition = target.position;

        float sqrRemainingDistance = (currentPosition - targetPosition).sqrMagnitude;

        bool isTargetReached = sqrRemainingDistance <= aiPath.endReachedDistance;

        return isTargetReached;
    }

    public void Attack()
    {
        animator.SetBool("Attacked", true);
        OnSheepAttacked?.Invoke();
    }


}
