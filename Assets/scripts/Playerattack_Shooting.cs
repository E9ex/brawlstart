using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

public class Playerattack_Shooting : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Joystick attackjoystick;
    [SerializeField] private Transform attacklookat;
    [SerializeField] public float lrdistance = 7f;
    [SerializeField] private Transform player;
    private RaycastHit hit;
    private bool shoot;
    [SerializeField] private Transform Bulletprefab;

    [SerializeField] private float bulletspeed = 10f;
    [SerializeField] private GameObject bulletspawnpoint;
    // Update is called once per frame


    void Update()
    {
        // if (Mathf.Abs(attackjoystick.Horizontal)>.5f || Mathf.Abs(attackjoystick.Vertical)>.5f)
        // {
        //     // if (lr.gameObject.activeInHierarchy==false)
        //     // {
        //     //     lr.gameObject.SetActive(true);
        //     // }
        //     transform.position = new(player.position.x, .1f, player.position.z);
        //     attacklookat.position = new Vector3(attackjoystick.Horizontal+transform.position.x, .1f, attackjoystick.Vertical+transform.position.z);
        //     transform.LookAt(new Vector3(attacklookat.position.x,0,attacklookat.position.z));
        //     transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        //     lr.SetPosition(0,transform.position);//başlangıç noktasını 0. pozisyonunu nesnenin mevcut konumuna ayarlar
        //     if (Physics.Raycast(transform.position,transform.forward,out hit,lrdistance))
        //     {
        //         lr.SetPosition(1,hit.point);//1 pozisyonunu, bu çarpışma noktasına ayarlar. (bunu yazmazsam obstacleslara gitmiyor linerenderer.)
        //        
        //     }
        //     else
        //     {
        //       lr.SetPosition(1,transform.forward+transform.forward*lrdistance);//Bu, çarpışma olmadığında lazer hattının belirtilen uzaklıkta düz bir çizgi olarak görüneceği demek.(bunu yazmazsam ise sadece obstaclelari gidiyor linerenderer.)
        //         lr.SetPosition(1,new Vector3(lr.GetPosition(1).x,.1f,lr.GetPosition(1).z));//çarpışma olmadığında, lazer hattının ikinci noktasını ayarlar.
        //        
        //     }
        //     if (shoot==false)
        //     {
        //         shoot=true;
        //     }
        // }
        //  if (shoot&&Input.GetMouseButtonUp(0))
        // {
        //     Instantiate(bullet, bulletspawnpoint.transform.position, quaternion.identity);
        //     // shoot = false;
        // }
        // else if (lr.gameObject.activeInHierarchy==true)
        // {
        //     lr.gameObject.SetActive(false);
        // }
    }
    // public void playershooting()
    // {
    //     if (shoot)
    //     {
    //         shoot=true;
    //     }  
    // }
    //
    // void Fire()
    // {
    //     Transform bullet = Instantiate(Bulletprefab, transform.position, transform.rotation);
    //     
    //     // Kurşuna hız verin
    //     Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
    //     if (bulletRigidbody != null)
    //     {
    //         bulletRigidbody.velocity = transform.forward * bulletspeed;
    //     }
    //     else
    //     {
    //         Debug.LogError("Kurşun nesnesi bir Rigidbody bileşeni içermiyor.");
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("enemy"))
        {
            other.transform.GetComponent<Enemy>().takedamage(20);
            Destroy(this.gameObject);
        }else
        {
            Destroy(this.gameObject);
        }
    }
}
