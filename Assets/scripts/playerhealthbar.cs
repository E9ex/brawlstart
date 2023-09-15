using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerhealthbar : MonoBehaviour
{
    public Slider Slider;

    public void Setmaxhealth(float health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    } 

    public void Sethealth(float health)
    {
        Slider.value = health;
    }
}
