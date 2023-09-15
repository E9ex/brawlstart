using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerUIlookcamera : MonoBehaviour
{
   private Camera maincamera;
   private void Awake()
   {
  maincamera=Camera.main;
 
   }



   private void Update()
   {
      if (maincamera!=null)
      {
         transform.LookAt(transform.position+maincamera.transform.rotation*Vector3.back,maincamera.transform.rotation*Vector3.up);
      }
   }
}
