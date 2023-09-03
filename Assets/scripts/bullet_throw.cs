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
    private void Start()
    {
        pa = GameObject.FindGameObjectWithTag("attacktrialthrow").GetComponent<Playerattack_Throw>();
        points = new Vector3[9];
        pa.bulletPoints.CopyTo(points,0);
        rb = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
    transform.Translate(Vector3.forward*speed);
    if (Throw)
    {
        transform.LookAt(points[currentIndex]);
    }
    else if ((points[currentIndex] - transform.position).sqrMagnitude < .2f) ;
    {
        if (currentIndex==8)
        {
            rb.useGravity = true;
        }
        currentIndex++;
        transform.LookAt(points[currentIndex]);
    } 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag=="enemy")
        {
            Destroy(this.gameObject);
        }
        else
        {
            StartCoroutine(Destroythis());
        }
    }

    IEnumerator Destroythis()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}