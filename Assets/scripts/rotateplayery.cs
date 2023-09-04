using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rotateplayery : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    private Touch touch;
    private bool pressed;
    [SerializeField] private Transform heroholder;
    [SerializeField] private GameObject characterselection;
    private bool move;
    void Update()
    {
        if (pressed)
        {
            if (Input.touchCount>0)
            {
            touch =  Input.GetTouch(0);
            if (touch.phase== TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > 0)
                {
                    heroholder.Rotate(0,-touch.deltaPosition.x,0);
                }
                move = true;
            }
        }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (move==false)
        {
            characterselection.SetActive(true);
        }

        pressed = false;
        move = false;

    }
}
