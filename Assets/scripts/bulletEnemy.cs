using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    public float life = 3;

    private playermovement playermovement;

    private void Awake()
    {
        playermovement = GetComponent<playermovement>();
        Destroy(gameObject,life);
    }

    private void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.CompareTag("Player"))
        {
            playermovement playermovement = other.transform.GetComponent<playermovement>();
            if (playermovement != null)
            {
                playermovement.takedamage(20f);
                Destroy(gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
