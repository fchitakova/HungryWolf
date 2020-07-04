using System;
using UnityEngine;

[Serializable]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    internal bool collidedWithSheep;
    internal bool collidedWithEnemy;

    internal Sheep collisionInvolvedSheep;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsSheepHit(collision))
        {
            Debug.Log("Collsion detected");
            collidedWithSheep = true;
            collisionInvolvedSheep = collision.collider.GetComponent<Sheep>();
        }

        if (IsEnemyHit(collision))
        {
            collidedWithEnemy = true;
        }

    }

    private bool IsSheepHit(Collision2D collision)
    {
        return collision.gameObject.CompareTag("FoodTarget");
    }

    private bool IsEnemyHit(Collision2D collision)
    {
        return collision.gameObject.CompareTag("Enemy");
    }


    public void OnCollisionExit2D(Collision2D other)
    {
        collidedWithSheep = false;
        collidedWithEnemy = false;

        collisionInvolvedSheep = null;
    }


}
