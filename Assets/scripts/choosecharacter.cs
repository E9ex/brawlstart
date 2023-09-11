using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choosecharacter : MonoBehaviour
{
    [SerializeField]private GameObject shootingmanprefab;
    [SerializeField] private GameObject Throwmanprefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Canvas lobbycanvas;
    

    public void buttonShootingman()
    {
        Instantiate(shootingmanprefab, playerSpawnPoint);
        lobbycanvas.enabled = false;
       
    }
    public void ButtonThrownMan()
    {
        Instantiate(Throwmanprefab, playerSpawnPoint);
        lobbycanvas.enabled = false;
        

    }
}
