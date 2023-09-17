using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartbutton : MonoBehaviour
{  
    public void Restartbutton()
    {
        // M_GameManager.I.LevelStart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("çalişiyorrestartbutton");
    }
}
