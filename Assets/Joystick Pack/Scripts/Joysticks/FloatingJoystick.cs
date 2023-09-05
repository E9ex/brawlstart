using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    [SerializeField] private Transform player;
    private string shoottype;
    private Playerattack_Shooting playerattackShooting;
    private Playerattack_Throw playerattackThrow;
    protected override void Start()
    {
        player = GameObject.Find("attacktrail").GetComponent<Transform>();
        if (player.GetComponent<Playerattack_Shooting>() != null)
        {
            shoottype = "shoot";
            playerattackShooting = GetComponent<Playerattack_Shooting>();
        }
        if (player.GetComponent<Playerattack_Throw>() != null)
        {
            shoottype = "throw";
            playerattackThrow = GetComponent<Playerattack_Throw>();
        }

        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        switch (shoottype)
        {
            case "shoot":
                playerattackShooting.playershooting();
                break;
            case "throw":
                playerattackThrow.playershooting();
                break;
            
        }
        
    }
}