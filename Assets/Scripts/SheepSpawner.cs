﻿using System.Collections;
using UnityEngine;
using static ScreenBoundaries;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sheeps;

    [SerializeField]
    [Range(0, 10)]
    private float spawnRate = 1.5f;

    private int currentSheepCount;


    public void OnEnable()
    {
        Sheep.OnSheepAttacked += DecrementSheepCount;
    }


    private void DecrementSheepCount()
    {
        --currentSheepCount;
    }

    public void OnDisable()
    {
        Sheep.OnSheepAttacked -= DecrementSheepCount;
    }

    void Start()
    {
        currentSheepCount = 0;
        StartCoroutine(SpawnSheeps());
    }


    private IEnumerator SpawnSheeps()
    {
        Vector2 spawnPosition;
        while(currentSheepCount <= sheeps.Length)
        {
            Debug.Log("New sheep!");
            spawnPosition = getRandomFreePositionInScreenBoundaries();
            Instantiate(sheeps[Random.Range(0, sheeps.Length)], spawnPosition, Quaternion.identity);

            ++currentSheepCount;

            yield return null;
        }
       
        yield return new WaitForSeconds(1f / spawnRate);
        StartCoroutine(SpawnSheeps());
    }

}
