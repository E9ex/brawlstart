using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private Playerattack pa;
    private Vector3 bulletenddist;
    [SerializeField] private float speed;
    void Start()
    {
        pa = GameObject.Find("attacktrail").GetComponent<Playerattack>();
        bulletenddist = transform.position + transform.forward * pa.lrdistance;
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
        if (other.transform.tag=="enemy")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
