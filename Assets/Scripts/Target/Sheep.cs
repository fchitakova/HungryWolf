using Pathfinding;
using System.Collections;
using UnityEngine;
using static ScreenBoundaries;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f;

    private AIDestinationSetter destinationSetter;

    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        StartCoroutine(MoveToTarget());
    }


    IEnumerator MoveToTarget()
    {
        Transform target = getRandomTarget();
       
        while (!isTargetReached(target))
        {
            yield return null;
        }

        float randomWaitTime = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomWaitTime);
        
        StartCoroutine(MoveToTarget());
    }

    private Transform getRandomTarget()
    {
        Vector2 target = getRandomFreePositionInsideScreenBoundaries();
        GameObject targetObject = new GameObject();
        targetObject.transform.position = target;

        return targetObject.transform;
    }


    private bool isTargetReached(Transform target) {
        float delta = 0.5f;
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        return distanceToTarget <= delta;
    }
    
}
