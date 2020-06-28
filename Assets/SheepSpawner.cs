using System.Collections;
using UnityEngine;
using static ScreenBoundaries;

public class SheepSpawner : MonoBehaviour
{

    private int currentSheepCount;

    [SerializeField]
    private GameObject[] sheeps;

    [SerializeField]
    [Range(0, 10)]
    private float spawnRate = 1.5f;

    void Start()
    {
        currentSheepCount = 0;
        StartCoroutine(SpawnSheeps());
    }


    private IEnumerator SpawnSheeps()
    {
        while (true)
        {
            Vector2 spawnPosition = getRandomPositionInsideScreenBoundaries(GameObject.FindWithTag("Enemy").transform.position);

            if (currentSheepCount <= sheeps.Length)
            {
                Instantiate(sheeps[Random.Range(0,sheeps.Length)], spawnPosition, Quaternion.identity);
                ++currentSheepCount;
            }
            yield return new WaitForSeconds(1f / spawnRate);
        }
    }

}
