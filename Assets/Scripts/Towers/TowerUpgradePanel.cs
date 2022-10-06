using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject  upgradeTowerButton; //, firerateButton, rangeButton, 
    public TMP_Text upgradeText; //rangeText, firerateText
    
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
