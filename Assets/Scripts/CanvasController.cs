using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject exitButton;

    private void Start() {
#if UNITY_WEBGL
  exitButton.SetActive(false);
#endif

#if UNITY_IOS
  exitButton.SetActive(false);
#endif
    }

    public void exitGame(){
        Application.Quit();
    }  
}
