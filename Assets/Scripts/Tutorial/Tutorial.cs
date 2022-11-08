using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialScreen; //main tutorial screen
    public GameObject[] screens; //tutorial screens
    public GameObject previousButton; //previous button game object

    int i = 0; //index of screen

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<UIController>().playTutorial)
        {
            activateScreens();
        }
    }

    public void activateTutorial()
    {
        tutorialScreen.SetActive(true);
    }

    public void deactivateTutorial()
    {
        tutorialScreen.SetActive(false);
        GetComponent<UIController>().playTutorial = false;
        Time.timeScale = 1f;
    }

    public void activateScreens()
    {
        if(i < screens.Length)
        {
            screens[i].SetActive(true);
            if (i != 0)
            {
                screens[i - 1].SetActive(false);
                previousButton.SetActive(true);
            }
            else
            {
                previousButton.SetActive(false);
            }
        }
        else
        {
            deactivateTutorial();
        }
    }

    public void nextScreen()
    {
        Debug.Log("help");
        i++;
        Debug.Log(i);
    }

    public void previousScreen()
    {
        screens[i].SetActive(false);
        i--;
        Debug.Log(i);
    }

    public void skipTutorial()
    {
        deactivateTutorial();
    }
}
