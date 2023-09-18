using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFireforPlayershooting : MonoBehaviour
{
    public Transform bulletPrefab; 
    public float bulletSpeed = 10f;
    public GameObject bulletspawnpoint;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire(); 
        }
    }
    void Fire()
    {
        // Farenin pozisyonunu alın
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Fare pozisyonunu kameradan belirli bir mesafede alın (10 bir varsayılan değer olabilir)

        // Fare pozisyonunu dünya koordinatlarına dönüştürün
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Ateş noktası ve hedef arasındaki yönü hesaplayın
        Vector3 fireDirection = targetPosition - bulletspawnpoint.transform.position;

        // Ateş edin
        Transform bullet = Instantiate(bulletPrefab, bulletspawnpoint.transform.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            // Ateş yönüne göre hızı ayarlayın
            bulletRigidbody.velocity = fireDirection.normalized * bulletSpeed;
        }
    }
        // Transform bullet = Instantiate(bulletPrefab, bulletspawnpoint.transform.position, Quaternion.identity);
        // Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        // if (bulletRigidbody != null)
        // {
        //     bulletRigidbody.velocity = transform.forward * bulletSpeed;
        // }
}

