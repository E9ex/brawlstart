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
        Instantiate(shootingmanprefab, playerSpawnPoint.transform.position,playerSpawnPoint.transform.rotation);
        lobbycanvas.enabled = false;
       
    }
    public void ButtonThrownMan()
    {
        Instantiate(Throwmanprefab, playerSpawnPoint.transform.position,playerSpawnPoint.transform.rotation);
        lobbycanvas.enabled = false;
        

    }
}
