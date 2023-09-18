using UnityEngine;

public class M_EndGame : Singleton<M_EndGame>
{
    private bool isOpen = false;

    public void LosePanelOpen()
    {
        if(isOpen) return;
        isOpen = true;
        
        transform.localScale = Vector3.one;
    }
}
