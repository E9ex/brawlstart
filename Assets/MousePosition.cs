using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
     private Camera maincamera;

     private void Awake()
     {
         maincamera = FindObjectOfType<Camera>();
     }

     void Update()
    {
        if (maincamera != null)
        {
            Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                transform.position = raycastHit.point;
            }
        }
    }
}
