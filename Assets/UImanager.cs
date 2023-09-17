using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject endgamepanel;
    public TextMeshProUGUI youwintxt;
    public TextMeshProUGUI youlosetxt;

    public void setyouwintxt()
    {
        endgamepanel.gameObject.SetActive(true);
        youwintxt.gameObject.SetActive(true);
        youlosetxt.gameObject.SetActive(false);
    }
    public void setyoulosetxt()
    {
        endgamepanel.gameObject.SetActive(true);
        youwintxt.gameObject.SetActive(false);
        youlosetxt.gameObject.SetActive(true);
    }

    
}
