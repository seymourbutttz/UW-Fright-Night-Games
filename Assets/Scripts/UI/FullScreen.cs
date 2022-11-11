using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    public Toggle fullScreenToggle;

    public void Start()
    {
        fullScreenToggle.isOn = Screen.fullScreen;
    }

    public void fullScreen(bool toggle)
    {
        Screen.fullScreen = toggle;

        Debug.Log(toggle);
    }
}
