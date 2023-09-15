using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healtbarforplayers : MonoBehaviour
{
   public Slider Slider;

   public void setmaximumhealth(int health)
   {
      Slider.maxValue = health;
      Slider.value = health;
   }

   public void SetHealthh(int healthh)
   {
      Slider.value = healthh;
   }

}
