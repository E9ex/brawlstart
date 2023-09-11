using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_throw : MonoBehaviour
{
    private Playerattack_Throw pa;
    private Vector3[] points;
    private Rigidbody rb;
    [SerializeField] private float speed;
    bool Throw;
    private int currentIndex;
    private SphereCollider sphereCollider;
   
    private float damaget;
    private void Awake()
    {
        pa = GetComponent<Playerattack_Throw>();
        transform.position += transform.forward * .5f;
        
    }
    
    private void Start()
    {
     
        sphereCollider = GetComponent<SphereCollider>();
        points = new Vector3[9];
        rb = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed);
        if (Throw)
        {
            transform.LookAt(points[currentIndex]);
        }
        else if ((points[currentIndex] - transform.position).sqrMagnitude < 0.2f)
        {
            if (currentIndex < points.Length - 1) // Dizi boyutunu kontrol edin.
            {
                currentIndex++;
                transform.LookAt(points[currentIndex]);
            }
            else
            {
                rb.useGravity = true;
            }
        }
    }


    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.GetComponent<health>()!=null&& Time.time>damaget)
    //     {
    //         other.GetComponent<health>().Damage(damagethrow);
    //         damaget = Time.time + .3f;
    //     }
    // }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.transform.tag=="enemy")
    //     {
    //         Destroy(this.gameObject);
    //     }
    //     else
    //     {
    //        // sphereCollider.isTrigger = true;
    //         StartCoroutine(Destroythis());
    //     }
    // }
    

    IEnumerator Destroythis()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
