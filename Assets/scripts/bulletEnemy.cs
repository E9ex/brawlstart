using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject,life);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            playermovement playermovement = other.transform.GetComponent<playermovement>();
            if (playermovement != null)
            {
                playermovement.takedamage(20);
                Destroy(other.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
