using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject spawnPointPrefab;
    public int numberOfSpawnPoints = 3;
    void Start()
    {
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            Vector3 randomPosition;
            bool isPositionValid = false;

            // SpawnPoint'lerin mevcut nesnelerle çakışmadığından emin olun
            while (!isPositionValid)
            {
                randomPosition = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));

                // Belirlediğiniz konumda başka bir nesne var mı diye kontrol edin
                Collider[] colliders = Physics.OverlapSphere(randomPosition, 1f); // 1f çapında bir alan içinde çarpışmaları kontrol ediyoruz

                // SpawnPoint Layer'ına sahip olmayan bir nesne yoksa konum geçerli kabul edilir
                isPositionValid = true;
                foreach (var collider in colliders)
                {
                    if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
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


    // public GameObject spawnPointPrefab;
    // public int numberOfSpawnPoints = 3;
    //
    // void Start()
    // {
    //     
    //     for (int i = 0; i < numberOfSpawnPoints; i++)
    //     {
    //         Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f)); 
    //         Instantiate(spawnPointPrefab, randomPosition, Quaternion.identity);
    //     }
    // }
}
