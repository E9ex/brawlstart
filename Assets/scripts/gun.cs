using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
   public float range = 5f;
   public LayerMask targetLayer;

   private Transform currentTarget;
   public Transform bulletSpawnPoint;
   public GameObject bulletprefab;
   public float bulletspeed = 10f;
   public float rotationSpeed = 20f; 
   public float fireInterval = .5f; 
   private float timeSinceLastFire = 0f;


   private void Update()
   {
      Collider[] hitTargets = Physics.OverlapSphere(transform.position, range, targetLayer);

      if (hitTargets.Length > 0)
      {
         currentTarget = hitTargets[0].transform;
      }
      else
      {
         currentTarget = null;
      }

      if (currentTarget != null)
      {
         Vector3 targetDirection = currentTarget.position - transform.position;
         Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
         
         timeSinceLastFire += Time.deltaTime;
         if (timeSinceLastFire >= fireInterval)
         {
            Fire(); 
            timeSinceLastFire = 0f; 
         }
      }
   }
   private void Fire()
   {
      var bullet = Instantiate(bulletprefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
      bullet.GetComponent<Rigidbody>().velocity = -bulletSpawnPoint.forward * bulletspeed;
   }
}
