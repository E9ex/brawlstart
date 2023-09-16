using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
  public GameObject endgamepanel;
  public TextMeshProUGUI youwintxt;
  public TextMeshProUGUI youlosetxt;
  
  public void setyouwintxt( )
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
