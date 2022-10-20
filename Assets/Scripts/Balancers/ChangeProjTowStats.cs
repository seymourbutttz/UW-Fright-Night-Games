using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeProjTowStats : MonoBehaviour
{
    public TMP_Text pumpkinText;
    public GameObject projectile1, projectile2, projectile3;

   
    //change starting money
    //must be run at the start of the level if you want to test starting gold. cannot change system prefab
    public void startingGold(string gold) //take in text input from stat controller
    {
        int.TryParse(gold, out int Gold); //convert string to int
        MoneyManager.instance.currentMoney = Gold; //sets current gold to new gold value
        UIController.instance.goldText.text = Gold.ToString(); //changes text on gold panel
    }

    //change pumpkin tower cost
    public void pumpkinCost(string cost) //take in text input from stat controller
    {
        int.TryParse(cost, out int Cost); //convert string to int
        GetComponentInParent<SetStats>().projectileTower.GetComponent<Tower>().cost = Cost; //sets current cost of tower to new cost
        pumpkinText.text = "Pumpkin" + "\n" + "Tower" + "\n" + "(" + Cost + "G)"; //sets button text
    }

    //change pumpkin range
    public void pumpkinRange(string range)
    {
        float.TryParse(range, out float Range); //convert string to float
        GetComponentInParent<SetStats>().projectileTower.GetComponent<Tower>().range = Range; //changes prefab tower range

        GameObject[] pumpkinTowers = GameObject.FindGameObjectsWithTag("ProjectileTower"); //finds all pumpkin towers active in session and assigns to array
        foreach (GameObject tower in pumpkinTowers)
        {
            tower.GetComponent<Tower>().range = Range; //assigns the new range value to each tower in active session
        }
    }

    //change pumpkin fire rate
    public void pumpkinRate(string rate)
    {
        float.TryParse(rate, out float Rate);
        GetComponentInParent<SetStats>().projectileTower.GetComponent<Tower>().fireRate = Rate;

        GameObject[] pumpkinTowers = GameObject.FindGameObjectsWithTag("ProjectileTower"); //finds all pumpkin towers active in session and assigns to array
        foreach (GameObject tower in pumpkinTowers)
        {
            tower.GetComponent<Tower>().fireRate = Rate; //assigns the new fire rate value to each tower in active session
        }
    }

    //change base damage
    public void pumpkinBaseDamage(string dam)
    {
        float.TryParse(dam, out float Dam); //convert string to float
        projectile1.GetComponent<Projectile>().damageAmount = Dam; //changes prefab damage amount

        GameObject[] seeds = GameObject.FindGameObjectsWithTag("Seed"); //finds all pumpkin seeds active in session and assigns to array
        foreach (GameObject seed in seeds)
        {
            seed.GetComponent<Projectile>().damageAmount = Dam; //assigns the new fire rate value to each tower in active session
        }
    }

    //chagne lvl 2 cost
    public void pumpkinCost2(string cost2)
    {
        int.TryParse(cost2, out int Cost2); //convert string to float
        GetComponentInParent<SetStats>().projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //sets upgrade1 cost of tower to new cost
        //pumpkinText.text = "Pumpkin" + "\n" + "Tower" + "\n" + "(" + Cost2 + "G)"; //sets button text

        GameObject[] pumpkinTowers = GameObject.FindGameObjectsWithTag("ProjectileTower"); //finds all pumpkin towers active in session and assigns to array
        foreach (GameObject tower in pumpkinTowers)
        {
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //assigns the new upgrade cost to each tower in active session
        }
    }

    //change lvl 2 range
    public void pumpkinRange2(string range2)
    {
        float.TryParse(range2, out float Range2); //convert string to float
        GetComponentInParent<SetStats>().projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //changes prefab tower lvl 2 range

        GameObject[] pumpkinTowers = GameObject.FindGameObjectsWithTag("ProjectileTower"); //finds all pumpkin towers active in session and assigns to array
        foreach (GameObject tower in pumpkinTowers)
        {
            if(tower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 1
            {
                tower.GetComponent<Tower>().range = Range2; //assigns the new range2 value to each tower upgraded lvl 1 tower in active session
            }
            tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //assigns the new range2 value to each tower in active session
        }
    }
}
