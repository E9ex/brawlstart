using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    [SerializeField] Transform player;
    private string Shootype;
    private Playerattack_Shooting playerattackShooting;
    private Playerattack_Throw playerattackThrow;
    protected override void Start()
    {
        player = GameObject.Find("attacktrail").GetComponent<Transform>();
        if (player.GetComponent<Playerattack_Shooting>()!=null)
        {
            Shootype = "Shooter";
            playerattackShooting = player.GetComponent<Playerattack_Shooting>();
        }
        else if (player.GetComponent<Playerattack_Throw>()!=null)
        {
            Shootype = "Throw";
            playerattackThrow = player.GetComponent<Playerattack_Throw>();
        }
        base.Start();
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
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        switch (Shootype)
        {
            case "Shoot":
                playerattackShooting.playershooting();
                break;
            case "throw":
                playerattackThrow.playershooting();
                break;
            default:
                break;
        }
    }
}