using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    private float Health;

    [SerializeField] private HealthEnum charactertype;
   [SerializeField] private Slider slider;
    void Start()
    {
        Health = (float)charactertype;
        slider.value = Health;
        slider.maxValue = Health;
    }

    public void Damage(float damageValue)
    {
        Health = damageValue;
        slider.value -= damageValue;
        if (Health<=0)
        {
            Debug.Log("player died");
        }
    }
    

}
