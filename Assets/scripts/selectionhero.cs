using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionhero : MonoBehaviour
{
    public GameObject[] heroes;
    private int heroIndex;
    private gobackscripts gobackscripts;
    void Start()
    {
        changehero();
    }

    public void changehero()
    {
        for (int i = 0; i < heroes.Length; i++)
        {
            if (i== heroIndex)
            {
                heroes[i].gameObject.SetActive(true);
            }
            else
            {
                heroes[i].gameObject.SetActive(false);
            }
        }
    }

    public void selectShooter()
    {
        heroIndex = 0;
        changehero(); 
        gobackscripts.goback();
    }
    public void selectthrow()
    {
        heroIndex = 1;
        changehero();
        gobackscripts.goback();
    }
}
