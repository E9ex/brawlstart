using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera maincamera;
    void Update()
    {
       Ray ray= maincamera.ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out RaycastHit raycastHit))
       {
           transform.position = raycastHit.point;
       }
    }
}
