using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class StatController : MonoBehaviour
{
    //script for stat control for playtesting

    public bool showConsole = false; //show stat console
    //public string input;

    
    public void OnToggleDebug()
    {
        showConsole = !showConsole;
        Debug.Log(showConsole);
        if (showConsole & UIController.instance.pauseScreen.activeSelf == false)
        {
            gameObject.GetComponent<UIController>().statScreen.SetActive(true);
            Time.timeScale = 0f;
        } else if(UIController.instance.pauseScreen.activeSelf == false)
        {
            gameObject.GetComponent<UIController>().statScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        

        
    }
}
