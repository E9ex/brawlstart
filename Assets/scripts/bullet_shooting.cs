using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shooting : MonoBehaviour
{
     private Playerattack_Shooting pa;
    private Vector3 bulletenddist;
    [SerializeField] private float speed;
    private int damagep = 20;
    private void Awake()
    {
        transform.position += transform.forward * .5f;
    }

    void Start()
    {
        pa = GameObject.Find("attacktrail").GetComponent<Playerattack_Shooting>();
        bulletenddist = transform.position + transform.forward * pa.lrdistance;// merminin gidebileceği yer.
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position==bulletenddist)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.forward*speed);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            // Çarpışma "enemy" etiketli bir nesneyle oldu
            Enemy enemyComponent = other.gameObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                // Eğer "Enemy" bileşeni varsa, "takedamage" fonksiyonunu çağırarak zarar verin
                enemyComponent.takedamage(damagep);
            }

            // Mermiyi yok edin
            Destroy(this.gameObject);
        }
    }
    
}
