using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1f;

    [SerializeField]
    protected float stopDistanceBeforeReachingTarget = 0.2f;

    [SerializeField]
    protected LayerMask blockingLayer;


    protected BoxCollider2D boxCollider;
    protected Rigidbody2D rigidBody;


    public virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    protected virtual bool MoveTo(Vector2 position)
    {
        Vector2 start = rigidBody.position;
        Vector2 target = start + position;

        bool isAnyColliderBetweenStartAndTarget = CheckForCollidersBetween(start, target);
        if (!isAnyColliderBetweenStartAndTarget)
        {
            StartCoroutine(MoveTowards(target));
            return true;
        }

        return false;
    }

    private bool CheckForCollidersBetween(Vector2 start,Vector2 target)
    {
        boxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(start, target, blockingLayer);
        boxCollider.enabled = true;

        bool isAnythingHit = (hit.transform != null);

        return isAnythingHit;
    }


    protected abstract IEnumerator MoveTowards(Vector2 targetPosition);
}