using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // activates credits scene

    public GameObject creditsScreen;
    
    //shows credit screen
    public void ShowCredits()
    {
        if (creditsScreen.activeSelf == false)
        {
            creditsScreen.SetActive(true);
        }
        else
        {
            creditsScreen.SetActive(false);
        }
    }
}
