using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject  upgradeTowerButton; //, firerateButton, rangeButton, 
    public TMP_Text upgradeText; //rangeText, firerateText
    public TMP_Text sellText; //button text to sell

    private Tower theTower;
    private int currentTowUpgrade;
    
    public void SetupPanel()
    {
        theTower = TowerManager.instance.selectedTower.GetComponent<Tower>();
        currentTowUpgrade = theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade;
        //sets text for upgrade button
        if (TowerManager.instance.selectedTower.upgrader.hasTowerUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            upgradeText.text = "Upgrade\nTower\n" + upgrader.towerUpgrades[upgrader.currentTowerUpgrade].cost + "G";

            upgradeTowerButton.SetActive(true);
        }
        else
        {
            upgradeTowerButton.SetActive(false);

        }
        //sets text for sell tower button
        if(theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 0)
        {
            sellText.text = "Sell\nTower\n" + theTower.sellPrice + "G";
        }
        else
        {
            sellText.text = "Sell\nTower\n" + theTower.GetComponent<TowerUpgradeController>().towerUpgrades[currentTowUpgrade - 1].sellCost + "G";
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
            //Debug.Log("Hello Matt");
        }

        //MoneyManager.instance.SpendMoney(-50);
        sellTower();

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

    public void sellTower()
    {
        int sellcost;
        int currentUpgrade;
        if (theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 0)
        {
            sellcost = theTower.sellPrice;
            MoneyManager.instance.SpendMoney(-sellcost);
        }
        else if (theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1)
        {
            //sellcost = (theTower.cost + theTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost) / 2;
            currentUpgrade = 0;
            sellcost = theTower.GetComponent<TowerUpgradeController>().towerUpgrades[currentUpgrade].sellCost;
            MoneyManager.instance.SpendMoney(-sellcost);
        }
        else if (theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2)
        {
            currentUpgrade = 1;
            //sellcost = (theTower.cost + theTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost + theTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost) / 2;
            sellcost = theTower.GetComponent<TowerUpgradeController>().towerUpgrades[currentUpgrade].sellCost;
            MoneyManager.instance.SpendMoney(-sellcost);
        }
    }
}
