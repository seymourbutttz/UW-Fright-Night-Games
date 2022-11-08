using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
        //Debug.Log("hello");
    }

    public TMP_Text goldText, pumpkinText, spiderText, bombText, shockText, meteorText;

    public GameObject pumpTower, spiderTower, bombTower, shockTower, meteorShower; //prefab to reference for cost

    public GameObject notEnoughMoneyWarning;

    public GameObject levelCompleteScreen, levelFailScreen;

    public GameObject towerButtons;

    public string levelSelectScene, mainMenuScene;

    public GameObject pauseScreen;

    public TowerUpgradePanel towerUpgradePanel;

    public TMP_Text waveText;

    //debug script canvas
    public GameObject statScreen;

    //play tutorial screens if true
    public bool playTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        
        if (playTutorial)
        {
            GetComponent<Tutorial>().activateTutorial();
            Time.timeScale = 0f;
        }

        pumpkinText.text = "Pumpkin" + "\n" + "Tower" + "\n" + pumpTower.GetComponent<Tower>().cost + "G"; //labels tower button with gold cost
        spiderText.text = "Spider" + "\n" + "Tower" + "\n" + spiderTower.GetComponent<Tower>().cost + "G";  //labels tower button with gold cost
        bombText.text = "Bomb" + "\n" + "Tower" + "\n" + bombTower.GetComponent<Tower>().cost + "G";  //labels tower button with gold cost
        meteorText.text = "Meteor" + "\n" + "Shower" + "\n" + meteorShower.GetComponent<Spells>().cost + "G"; //labels spell button with gold cost
        shockText.text = "Shock" + "\n" + "Tower" + "\n" + shockTower.GetComponent<Tower>().cost + "G"; //labels shock button with gold cost;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(levelSelectScene);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(mainMenuScene);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(LevelManager.instance.nextLevel);
    }

    public void OpenTowerUpgradePanel()
    {
        if (LevelManager.instance.levelActive & !TowerManager.instance.isPlacing)
        {
            towerUpgradePanel.gameObject.SetActive(true);
            towerUpgradePanel.SetupPanel();
        }
    }

    public void CloseTowerUpgradePanel()
    {
        towerUpgradePanel.gameObject.SetActive(false);

        if (TowerManager.instance.selectedTower != null)
        {
             TowerManager.instance.selectedTower.rangeModel.SetActive(false);
             TowerManager.instance.selectedTower = null;
        }

        TowerManager.instance.selectedTowerEffect.SetActive(false);

        notEnoughMoneyWarning.SetActive(false);
        
    }
}
