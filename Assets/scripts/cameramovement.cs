using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;

    // Update is called once per frame
    void Update()
    {
      
        transform.position = new Vector3(player.position.x, 3.71f, player.position.z+offset);
    }
}
