using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject  upgradeTowerButton; //, firerateButton, rangeButton, 
    public TMP_Text upgradeText; //rangeText, firerateText

    private Tower theTower;
    
    public void SetupPanel()
    {

        if (TowerManager.instance.selectedTower.upgrader.hasTowerUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            upgradeText.text = "Upgrade\nTower\n(" + upgrader.towerUpgrades[upgrader.currentTowerUpgrade].cost + "G)";

            upgradeTowerButton.SetActive(true);
        }
        else
        {
            upgradeTowerButton.SetActive(false);
        }
    }

    public void RemoveTower()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
        theTower = TowerManager.instance.selectedTower.GetComponent<Tower>();

        //resets slow effect if tower is a slow tower
        if (theTower.tag == "SlowTower")
        {
            theTower.GetComponent<SpiderTower>().RemoveSlowEffect(); //calls ResetEnemy function when slow tower is removed.
            Debug.Log("Hello Matt");
        }

        MoneyManager.instance.SpendMoney(-50);

        Destroy(TowerManager.instance.selectedTower.gameObject);

        UIController.instance.CloseTowerUpgradePanel();

        AudioManager.instance.PlaySFX(9);
    }


    public void UpgradeTower()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasTowerUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.towerUpgrades[upgrader.currentTowerUpgrade].cost))
            {
                upgrader.UpgradeTower();

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);

                AudioManager.instance.PlaySFX(10);
            }
            else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }
        }
    }
}
