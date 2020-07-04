using UnityEngine;

public class ScreenBoundaries
{
    private static Vector2 screenBoundaries = screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));


    public static Vector2 ClampObjectPositionInScreenBoundaries(float gameObjectWidth, float gameObjectHeight,Vector2 position)
    {
        Vector2 horizontalScreenBoundaries = new Vector2((-screenBoundaries.x) + gameObjectWidth, screenBoundaries.x - gameObjectWidth);
        Vector2 verticalScreenBoundaries = new Vector2((-screenBoundaries.y) + gameObjectHeight, screenBoundaries.y - gameObjectHeight);

        Vector2 newPositionInScreenBoundaries;
        newPositionInScreenBoundaries.x = Mathf.Clamp(position.x, horizontalScreenBoundaries.x, horizontalScreenBoundaries.y);
        newPositionInScreenBoundaries.y = Mathf.Clamp(position.y, verticalScreenBoundaries.x, verticalScreenBoundaries.y);

        return newPositionInScreenBoundaries;
    }



    public static Vector2 GetRandomFreePositionInScreenBoundaries()
    {
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-screenBoundaries.x, screenBoundaries.x);
            float randomY = Random.Range(-screenBoundaries.y, screenBoundaries.y);
            randomPosition = new Vector2(randomX, randomY);
        } while (!IsPositionFree(randomPosition));

        return randomPosition;

    }


    private static bool IsPositionFree(Vector2 position)
    {
        bool isPositionFree = (Physics2D.OverlapCircle(position, 1.5f) != null);
        return isPositionFree;
    }
}
