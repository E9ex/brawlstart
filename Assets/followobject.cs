using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followobject : MonoBehaviour
{
    public Transform target; 
    public float heightOffset = 3.5f; 

    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + heightOffset, target.position.z);
        transform.position = newPosition;
    }
}
