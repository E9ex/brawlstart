using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFireforPlayershooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f;
    public GameObject bulletspawnpoint;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            fire();
        }
    }
    void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletspawnpoint.transform.position, transform.rotation);
        Rigidbody mermiRigidbody = bullet.GetComponent<Rigidbody>();
        if (mermiRigidbody != null)
        {
            mermiRigidbody.velocity = transform.forward * mermiRigidbody.velocity.magnitude;
        }
    }
}

