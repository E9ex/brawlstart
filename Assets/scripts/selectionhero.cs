using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.SceneManagement;

public class selectionhero : MonoBehaviour
{
    public GameObject[] heroes;
    private int heroIndex;
    private gobackscripts gobackscripts;
    private string path;
    void Start()
    {
        path=Application.persistentDataPath + "/HeroIndex.bst";
        if (File.Exists(path))
        {
            BinaryReader bnr = new BinaryReader(File.Open(path, FileMode.Open));
            heroIndex = bnr.ReadInt32();
            bnr.Close();
            changehero();
        }
       
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

    void saveIndex()
    {
        if (File.Exists(Application.persistentDataPath+"/HeroIndex.bst"))
        {
            using (BinaryWriter bn =
                   new BinaryWriter(File.Open(Application.persistentDataPath + "/HeroIndex.bst", FileMode.Open)))
            {
                bn.Write(heroIndex);
            }
        }
        else
        {
            using (BinaryWriter bn =
                   new BinaryWriter(File.Open(Application.persistentDataPath + "/HeroIndex.bst", FileMode.Create)))
            {
                bn.Write(heroIndex);
            }
        }
    }

    public void selectShooter()
    {
        
        Debug.Log("seçiyorumshoot");
        if (heroIndex!=0)
        {
            heroIndex = 0;
            changehero();
            saveIndex();
        }
        gobackscripts.goback();
    }
    public void selectthrow()
    {
        Debug.Log("seçiyorumthrow");
        if (heroIndex!=1)
        {
            heroIndex =1;
            changehero();
            saveIndex();
        }
        gobackscripts.goback();
    }

    public void playbutton()
    {
        SceneManager.LoadScene(1);
    }
}
