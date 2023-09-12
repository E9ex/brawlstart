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
    [SerializeField] private Transform[] waypoints;//waypoints dizisi objelerin hareket edeceği noktaları tutacak.
    private int currentWayPointIndex = 0; // waypoints dizisindeki o anki hedef noktanın index numarasını tutar.
    [SerializeField] private float speed = 2f;//waypoints üzerinde hareket eden objelerin hızını tutacak.
    private bool isGoingForward = true;


    [Header("navmesh")]
    public NavMeshAgent agent;
    public float range; //radius of sphere

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
        if(agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    
        // if (waypoints.Length == 0)
        // {
        //     return;
        // }
        //
        // Vector3 targetPosition = waypoints[currentWayPointIndex].position;
        //
        // float distanceToWaypoint = Vector3.Distance(transform.position, targetPosition);
        //
        // if (distanceToWaypoint < 0.1f)
        // {
        //     if (isGoingForward)
        //     {
        //         currentWayPointIndex++;
        //         if (currentWayPointIndex >= waypoints.Length)
        //         {
        //             currentWayPointIndex = waypoints.Length - 2;
        //             isGoingForward = false;
        //         }
        //     }
        //     else
        //     {
        //         currentWayPointIndex--;
        //         if (currentWayPointIndex < 0)
        //         {
        //             currentWayPointIndex = 1;
        //             isGoingForward = true;
        //         }
        //     }
        // }
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        
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
    // public void animation()
    // {
    //     enemy.DOLocalMoveX(-290, 5f).SetLoops(-1, LoopType.Yoyo);
    // }

}
