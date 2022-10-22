using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeSpidTowStats : MonoBehaviour
{
 
    public TMP_Text spiderText; //text on spider tower button

    //change spider tower cost
    public void spiderCost(string cost) //take in text input from stat controller
    {
        int.TryParse(cost, out int Cost); //convert string to int
        GetComponentInParent<SetStats>().spiderTower.GetComponent<Tower>().cost = Cost; //sets current cost of tower to new cost
        spiderText.text = "Spider" + "\n" + "Tower" + "\n" + "(" + Cost + "G)"; //sets button text
    }

    //change spider range
    public void spiderRange(string range)
    {
        float.TryParse(range, out float Range); //convert string to float
        GetComponentInParent<SetStats>().spiderTower.GetComponent<Tower>().range = Range; //changes prefab tower range

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            tower.GetComponent<Tower>().range = Range; //assigns the new range value to each tower in active session
        }
    }

    //change spider slow rate
    public void spiderRate(string rate)
    {
        float.TryParse(rate, out float Rate);
        GetComponentInParent<SetStats>().spiderTower.GetComponent<Tower>().fireRate = Rate;

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            tower.GetComponent<SpiderTower>().balance = true;//notifies the system that a base level rate change has occured
            tower.GetComponent<Tower>().fireRate = Rate; //assigns the new fire rate value to each tower in active session
        }
    }

    //chagne lvl 2 cost
    public void spiderCost2(string cost2)
    {
        int.TryParse(cost2, out int Cost2); //convert string to float
        GetComponentInParent<SetStats>().spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //sets upgrade 1 cost of tower to new cost

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //assigns the new upgrade cost to each tower in active session
        }
    }

    //change lvl 2 range
    public void spiderRange2(string range2)
    {
        float.TryParse(range2, out float Range2); //convert string to float
        GetComponentInParent<SetStats>().spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //changes prefab tower lvl 2 range

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            if(tower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 2
            {
                tower.GetComponent<Tower>().range = Range2; //assigns the new range2 value to each tower upgraded lvl 1 tower in active session
            }
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //assigns the new range2 value to each tower in active session
        }
    }

    //change spider lvl 2 fire rate
    public void spiderRate2(string rate2)
    {
        float.TryParse(rate2, out float Rate2); //converts string to float
        GetComponentInParent<SetStats>().spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].speed = Rate2; //sets level 2 fire rate

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            if (tower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 2
            {
                tower.GetComponent<Tower>().fireRate = Rate2; //assigns the new range2 value to each tower upgraded lvl 1 tower in active session
            }
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].speed = Rate2; //assigns the new fire rate value to each tower in active session
        }
    }

    //change lvl 3 cost
    public void spiderCost3(string cost3)
    {
        int.TryParse(cost3, out int Cost3); //convert string to float
        GetComponentInParent<SetStats>().spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3; //sets upgrade lvl 3 cost of prefab tower to new cost

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3; //assigns the new upgrade cost to each tower in active session
        }
    }

    //change lvl 3 range
    public void spiderRange3(string range3)
    {
        float.TryParse(range3, out float Range3); //convert string to float
        GetComponentInParent<SetStats>().spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3; //changes prefab tower lvl 3 range

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            if (tower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //looks to see if active towers are upgraded to level 3
            {
                tower.GetComponent<Tower>().range = Range3; //assigns the new range3 value to each lvl 3 tower in active session
            }
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3; //assigns the new range2 value to each tower in active session
        }
    }

    //change pumpkin lvl 3 fire rate
    public void spiderRate3(string rate3)
    {
        float.TryParse(rate3, out float Rate3); //converts string to float
        GetComponentInParent<SetStats>().spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed = Rate3; //sets level 3 fire rate of tower prefab

        GameObject[] spiderTowers = GameObject.FindGameObjectsWithTag("SlowTower"); //finds all spider towers active in session and assigns to array
        foreach (GameObject tower in spiderTowers)
        {
            if (tower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //looks to see if active towers are upgraded to level 3
            {
                tower.GetComponent<Tower>().fireRate = Rate3; //assigns the new range3 value to each lvl 3 tower in active session
            }
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed = Rate3; //assigns the new fire rate value to each tower in active session
        }
    }
}
