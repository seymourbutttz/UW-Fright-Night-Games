using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public static Options instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject optionsScreen; //option screen to activate/deactivate
    public GameObject audioManager; //audio manager pre-fab

    //shows/hides options screen
    public void ShowOptions()
    {
        if (optionsScreen.activeSelf == false)
        {
            optionsScreen.SetActive(true);
        }
        else
        {
            optionsScreen.SetActive(false);
        }
    }
}
