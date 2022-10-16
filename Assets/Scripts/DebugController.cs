using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{

    public bool showConsole = false;
    public string input;

    
    public void OnToggleDebug()
    {
        showConsole = !showConsole;
        Debug.Log(showConsole);


        
    }

    private void OnGUI()
    {

        if (showConsole)
        {

            float y = Screen.height - 30f;

            GUI.Box(new Rect(0, y, Screen.width, 40), "");
            GUI.backgroundColor = new Color(0, 0, 0, 0);
            GUI.SetNextControlName("console");
            input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
            GUI.FocusControl("console");
            //input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);


        }

        //if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
        //{
        //    HandleInput();
        //    input = "";
        //}
    }
}
