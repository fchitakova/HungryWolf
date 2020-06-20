using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour {
    private float moveSpeed = 0.5f;
    private Vector2 targetSpot;
    private float maxWaitTime;
    public float remainingWaitTime;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    void Start () {
        remainingWaitTime = maxWaitTime;
    }

    void Update () {
        if (remainingWaitTime <= 0) {
            targetSpot = new Vector2 (Random.Range (minX, maxX), Random.Range (minY, maxY));
            StartCoroutine (moveTowardsTarget ());
        }
        remainingWaitTime -= Random.Range (1, 5);
    }

    IEnumerator moveTowardsTarget () {
        while (Vector2.Distance (transform.position, targetSpot) <= 0.2f) {
            Vector2 currentPosition = transform.position;
            transform.position = Vector2.MoveTowards (currentPosition, targetSpot, moveSpeed * Time.deltaTime);
            currentPosition = transform.position;

            yield return null;
        }
        yield break;
    }

}