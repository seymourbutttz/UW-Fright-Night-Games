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
        if (showConsole)
        {
            gameObject.GetComponent<UIController>().statScreen.SetActive(true);
            Time.timeScale = 0f;
        } else
        {
            gameObject.GetComponent<UIController>().statScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        

        
    }


    //function to display Command line.
    //https://www.youtube.com/watch?v=VzOEM-4A2OM&t=1
    //private void OnGUI()
    //{

    //    if (showConsole)
    //    {

    //        float y = Screen.height - 30f;

    //        GUI.Box(new Rect(0, y, Screen.width, 40), "");
    //        GUI.backgroundColor = new Color(0, 0, 0, 0);
    //        GUI.SetNextControlName("console");
    //        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    //        GUI.FocusControl("console");
    //        //input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);


    //    }

    //    //if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
    //    //{
    //    //    HandleInput();
    //    //    input = "";
    //    //}
    //}
}
