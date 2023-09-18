using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_EndGameWin : Singleton<M_EndGameWin>
{
    private bool isOpen = false;

  
    public void WinPanelOpen()
    {
        if(isOpen) return;
        isOpen = true;
        
        transform.localScale = Vector3.one;
    }
    
}
