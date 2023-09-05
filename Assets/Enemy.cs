using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public healthbarscript healthbar;
  //  private Transform enemy;
    private Animator forwardsandbackwards;
    public GameObject deathExp;
    [SerializeField] private GameObject[] waypoints;//waypoints dizisi objelerin hareket edeceği noktaları tutacak.
    private int currentWayPointIndex = 0; // waypoints dizisindeki o anki hedef noktanın index numarasını tutar.
    [SerializeField] private float speed = 2f;//waypoints üzerinde hareket eden objelerin hızını tutacak.

    private void Awake()
    {
        forwardsandbackwards = GetComponent<Animator>();
      //  enemy = GetComponent<Transform>();
    }

    private void Start()
    {
        currenthealth = maxhealth;
        healthbar.setmaxhealth(maxhealth);
    }

 
    void Update()
    {
        Vector3 targetPosition = new Vector3(waypoints[currentWayPointIndex].transform.position.x, waypoints[currentWayPointIndex].transform.position.y, transform.position.z);

        if (Vector2.Distance(new Vector2(targetPosition.x, targetPosition.y), new Vector2(transform.position.x, transform.position.y)) < 0.1f)
        {
            currentWayPointIndex++;

            if (currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
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
