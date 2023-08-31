using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Transform playersprite;
    [SerializeField] private Animator anim;
    private bool movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal>0|| joystick.Horizontal<0 || joystick.Vertical>0|| joystick.Vertical<0)
        {
            playersprite.position = new Vector3(joystick.Horizontal+transform.position.x, .1f, joystick.Vertical+transform.position.z);
            transform.LookAt(new Vector3(playersprite.position.x,0,playersprite.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.Translate(Vector3.forward*Time.deltaTime);
            if (anim.GetBool("walking")!=true)
            {
                anim.SetBool("walking",true);
            }

            movement = true;
        }
        else if (movement==true)
        {
            anim.SetBool("walking",false);
            movement = false;
        }
        
    }
}
