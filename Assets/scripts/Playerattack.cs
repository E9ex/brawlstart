using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Joystick attackjoystick;
    [SerializeField] private Transform attacklookat;
    [SerializeField] public float lrdistance = 1f;
    [SerializeField] private Transform player;
    private RaycastHit hit;
    private bool shoot;
    [SerializeField] private Transform bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(attackjoystick.Horizontal)>.5f || Mathf.Abs(attackjoystick.Vertical)>.5f)
        {
            // if (lr.gameObject.activeInHierarchy==false)
            // {
            //     lr.gameObject.SetActive(true);
            // }
            transform.position = new(player.position.x, .1f, player.position.z);
            attacklookat.position = new Vector3(attackjoystick.Horizontal+transform.position.x, .1f, attackjoystick.Vertical+transform.position.z);
            transform.LookAt(new Vector3(attacklookat.position.x,0,attacklookat.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            lr.SetPosition(0,transform.position);
            if (Physics.Raycast(transform.position,transform.forward,out hit,lrdistance))
            {
                lr.SetPosition(1,hit.point);
            }
            else
            {
                lr.SetPosition(1,transform.forward+transform.forward*lrdistance);
                lr.SetPosition(1,new Vector3(lr.GetPosition(1).x,.1f,lr.GetPosition(1).z));
            }

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
        // else if (lr.gameObject.activeInHierarchy==true)
        // {
        //     lr.gameObject.SetActive(false);
        // }
    }
}
