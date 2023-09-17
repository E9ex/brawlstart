using System;
using UnityEngine;

public class CannonBall : MonoBehaviour 
{
    [SerializeField]
    GameObject deathEffect;

    string selfTag;
    private Enemy enemyfordamage;

    private void Awake()
    {
        enemyfordamage = GetComponent<Enemy>();
    }

    public void SetTag(string newTag)
    {
        selfTag = newTag;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(selfTag)) return;
        
        Debug.Log("MERMI PATLIYOR " + collision.gameObject.tag);
        Instantiate(deathEffect, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("enemy"))
        {
            Enemy enemyComponent = collision.gameObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.takedamage(20);
            }
        }
    }
}
