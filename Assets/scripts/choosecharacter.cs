using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choosecharacter : MonoBehaviour
{
    [SerializeField]private GameObject shootingmanprefab;
    [SerializeField] private GameObject Throwmanprefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private GameObject lobbycanvas;
    

    public void buttonShootingman()
    {
        Instantiate(shootingmanprefab, playerSpawnPoint.transform.position,playerSpawnPoint.transform.rotation);
        lobbycanvas.gameObject.SetActive(false);
        
        M_GameManager.I.LevelStart();
       
    }
    public void ButtonThrownMan()
    {
        Instantiate(Throwmanprefab, playerSpawnPoint.transform.position,playerSpawnPoint.transform.rotation);
        lobbycanvas.gameObject.SetActive(false);
        
        M_GameManager.I.LevelStart();
    }
}
