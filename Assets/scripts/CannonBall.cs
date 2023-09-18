using System;
using UnityEngine;

public class CannonBall : MonoBehaviour 
{
    [SerializeField]
    GameObject deathEffect;

    string selfTag;
    private Enemy enemyfordamage;

    [SerializeField] Transform model;

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
        
        // RayCastArea();
        
        Instantiate(deathEffect, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        Destroy(gameObject);
    }

    void RayCastArea()
    {
        Debug.Log("ENEMY TRY! ");
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, 100, transform.forward, out hit, 100))
        {
            Debug.Log("ENEMY FOUND! " + hit.collider.name);
            var rb = hit.collider.attachedRigidbody;
            if (!rb) return;
            
            if(rb.TryGetComponent(out Enemy script))
                script.takedamage(20);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 10);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Enemy enemyComponent = other.gameObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.takedamage(20);
               
            }
            Destroy(this.gameObject);
        }
    }

    Vector3 lastPosition;
    private void Update()
    {
        model.forward = transform.position - lastPosition;
        lastPosition = transform.position;
    }
}
