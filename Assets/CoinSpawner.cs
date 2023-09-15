using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject spawnPointPrefab;
    public int numberOfSpawnPoints = 2;

    void Start()
    {
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            Vector3 randomPosition;
            bool isPositionValid = false;
            while (!isPositionValid)
            {
                randomPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
                Collider[] colliders = Physics.OverlapSphere(randomPosition, 0.1f);
                isPositionValid = true;
                foreach (var collider in colliders)
                {
                    if (collider.CompareTag("enemy"))
                    {
                        isPositionValid = false;
                        break;
                    }
                }
                if (isPositionValid)
                {
                    Instantiate(spawnPointPrefab, randomPosition, Quaternion.identity);
                }
            }
        }
    }
}

