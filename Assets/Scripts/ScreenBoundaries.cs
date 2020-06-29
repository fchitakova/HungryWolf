using UnityEngine;

public class ScreenBoundaries
{
    private static Vector2 screenBoundaries;
    private Vector2 horizontalScreenBoundaries;
    private Vector2 verticalScreenBoundaries;


    public  ScreenBoundaries(float gameObjectWidth,float gameObjectHeight)
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        horizontalScreenBoundaries = new Vector2((-screenBoundaries.x) + gameObjectWidth, screenBoundaries.x - gameObjectWidth);
        verticalScreenBoundaries = new Vector2((-screenBoundaries.y) + gameObjectHeight, screenBoundaries.y - gameObjectHeight);
    }

    public Vector2 clampNewPositionInScreenBoundaries(Vector2 position)
    {
        Vector2 newPositionInScreenBoundaries;
        newPositionInScreenBoundaries.x = Mathf.Clamp(position.x, horizontalScreenBoundaries.x, horizontalScreenBoundaries.y);
        newPositionInScreenBoundaries.y = Mathf.Clamp(position.y, verticalScreenBoundaries.x, verticalScreenBoundaries.y);
        return newPositionInScreenBoundaries;
    }





    public static Vector2 getRandomFreePositionInScreenBoundaries()
    {
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-screenBoundaries.x, screenBoundaries.x);
            float randomY = Random.Range(-screenBoundaries.y, screenBoundaries.y);
            randomPosition = new Vector2(randomX, randomY);
        } while (!isPositionFree(randomPosition));

        return randomPosition;

    }


    private static bool isPositionFree(Vector2 position)
    {
        bool isPositionFree = (Physics2D.OverlapCircle(position, 1.5f) != null);
        return isPositionFree;
    }
}
