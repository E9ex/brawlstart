using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InstantiateHero : MonoBehaviour
{
    [SerializeField]private Transform[] heroprefabs;
    private string path;
    void Start()
    { 
        path=Application.persistentDataPath + "/HeroIndex.bst";
        if (File.Exists(path))
        {
            BinaryReader bnr = new BinaryReader(File.Open(path, FileMode.Open));
            Instantiate(heroprefabs[bnr.ReadInt32()]);
            bnr.Close();
            
            
        }
    }


}
