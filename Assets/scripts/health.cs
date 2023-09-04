using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    private float Health;

    [SerializeField] private HealthEnum charactertype;
  
    void Start()
    {
        Health = (float)charactertype;
    
    }

    public void Damage(float damageValue)
    {
        Health = damageValue;
     
        if (Health<=0)
        {
            Debug.Log("player died");
        }
    }
    

}
