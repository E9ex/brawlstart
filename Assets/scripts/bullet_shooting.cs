using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shooting : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public int damage = 20;
    public float bulletLifetime = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,bulletLifetime);
    }

    void Update()
    {
        // Mermiyi ileri doğru hareket ettir.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("enemy"))
        {
            Enemy enemyComponent = other.gameObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.takedamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
