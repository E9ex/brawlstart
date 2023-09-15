using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerhealthbar : MonoBehaviour
{
    public Slider Slider;

    public void setmaxhealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    } 

    public void sethealth(int health)
    {
        Slider.value = health;
    }
}
