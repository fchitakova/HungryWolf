using System.Collections;
using UnityEngine;
using static ScreenBoundaries;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f;

    private Vector2 target;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveToTarget());
    }


    IEnumerator MoveToTarget()
    { 
        target = getRandomFreePosition();
       
        while (!isTargetReached())
        {

            rigidBody.MovePosition(target * speed * Time.fixedDeltaTime);

            yield return null;
        }

        float randomWaitTime = Random.Range(0.5f, 5f);
        yield return new WaitForSeconds(randomWaitTime);
        
        StartCoroutine(MoveToTarget());
    }

    private Vector2 getRandomFreePosition()
    {
        Vector2 randomPosition = getRandomPositionInsideScreenBoundaries(rigidBody.transform.position);
        while (!isPositionFree(randomPosition))
        {
            randomPosition = getRandomPositionInsideScreenBoundaries(rigidBody.transform.position);
        }

        return randomPosition;
    }


    private bool isTargetReached() {
        float delta = 0.5f;
        float distanceToTarget = Vector2.Distance(rigidBody.position, target);

        return distanceToTarget <= delta;
    }
    


    private bool isPositionFree(Vector2 position)
    {
        bool isPositionFree = (Physics2D.OverlapCircle(position, 1.5f) != null);
        return isPositionFree;
    }
    
}
