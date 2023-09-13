using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public healthbarscript healthbar;
  //  private Transform enemy;
    private Animator forwardsandbackwards;
    public GameObject deathExp;
    [Header("navmesh")]
    public NavMeshAgent agent;
    public float range;
    [SerializeField] private Animator anim;
    private bool movement;

    public Transform centrePoint;
    private void Awake()
    {
        forwardsandbackwards = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //  enemy = GetComponent<Transform>();
    }

    private void Start()
    {
        currenthealth = maxhealth;
        healthbar.setmaxhealth(maxhealth);
    }

 
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) 
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                agent.SetDestination(point);

               
                if (!anim.GetBool("walkingg"))
                {
                    anim.SetBool("walkingg", true);
                }
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;  
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        { 
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


    public void takedamage(int damage)
    {
        currenthealth -= damage;
        healthbar.sethealth(currenthealth);

        if (currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Instantiate(deathExp, transform.position, Quaternion.identity);
    }
   

}
