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

    // private void Update()
    // {
    //     
    //     animation();
    // }

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
