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



    /*
    public static Vector2 getRandomPositionOutOfScreen() {
        int direction = -1;
        Vector2 spawnPosition = new Vector2(direction * screenBoundaries.x , direction * screenBoundaries.y );
        spawnPosition.x += direction*Random.Range(0.3f, 1.3f);
        spawnPosition.y += direction* Random.Range(0.3f, 1.3f);
       
        return spawnPosition;
    }*/

    public static Vector2 getRandomPositionInsideScreenBoundaries(Vector2 startPosition)
    {
        float randomX = Random.Range((-screenBoundaries.x)+startPosition.x, screenBoundaries.x-startPosition.x);
        float randomY = Random.Range((-screenBoundaries.y)+startPosition.y,screenBoundaries.y-startPosition.y);
        return new Vector2(randomX, randomY);
    }

}
