 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack_Throw : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Joystick attackjoystick;
    [SerializeField] private Transform attacklookat;
    [SerializeField] public float lrdistance = 7f;
    [SerializeField] private Transform player;
    private RaycastHit hit;
    private bool shoot;
    [SerializeField] private Transform bullet;

    public Vector3[] bulletPoints;
    [SerializeField] private float linepower_y;

    private void Start()
    {
        lr.positionCount = 10;
        bulletPoints = new Vector3[9];
    }

    void Update()
    {
        if (Mathf.Abs(attackjoystick.Horizontal)>.5f || Mathf.Abs(attackjoystick.Vertical)>.5f)
        {
          
            transform.position = new(player.position.x, .1f, player.position.z);
            attacklookat.position = new Vector3(attackjoystick.Horizontal+transform.position.x, .1f, attackjoystick.Vertical+transform.position.z);
            transform.LookAt(new Vector3(attacklookat.position.x,0,attacklookat.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            
            lr.SetPosition(0,-new Vector3(transform.position.x,transform.position.y+1,transform.position.z));//başlangıç noktasını 0. pozisyonunu nesnenin mevcut konumuna ayarlar
            
            for (int i = 1; i < 10; i++)
            {
                float yOffset = i == 1 ? 0.3f : Mathf.Cos(linepower_y * (i * 0.1f)) * (i * 0.04f);
                lr.SetPosition(i, new Vector3(lr.GetPosition(i - 1).x + attackjoystick.Horizontal, 0.1f + yOffset, lr.GetPosition(i - 1).z + attackjoystick.Vertical));
            }
            // for (int i = 1; i < 10; i++)
            // {
            //     float x = lr.GetPosition(i - 1).x + attackjoystick.Horizontal;
            //     float z = lr.GetPosition(i - 1).z + attackjoystick.Vertical;
            //     float y = Mathf.Sin(linepower_y * (i * 0.1f)) * (i * 0.4f); // Sinus fonksiyonunu kullanarak yüksekliği ayarlayın
            //     lr.SetPosition(i, new Vector3(x, 0.1f + y, z));
            // }


            // for (int i = 1; i < 10; i++)
            // {
            //     lr.SetPosition(i,new Vector3(lr.GetPosition(i-1).x+attackjoystick.Horizontal,i==1?.3f:Mathf.Cos(linepower_y*(i*.1f))*(i*.4f),lr.GetPosition(i-1).z+attackjoystick.Vertical));
            //    
            // }
            if (shoot==false)
            {
                shoot=true; 
            }
        }
        else if (shoot&&Input.GetMouseButtonUp(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shoot = false;
        }
   
    }
    public void playershooting()
    {
        if (shoot) 
        {
            shoot=true;
        }  
    }
}
