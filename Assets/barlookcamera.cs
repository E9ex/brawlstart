using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barlookcamera : MonoBehaviour
{
    public Camera _maincamera;
    void Update()
    {
        transform.LookAt(transform.position+_maincamera.transform.rotation*Vector3.back,_maincamera.transform.rotation*Vector3.up);
    }
}
