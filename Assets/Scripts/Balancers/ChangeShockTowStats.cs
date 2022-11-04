using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ChangeShockTowStats : MonoBehaviour
{
 
    public TMP_Text shockText; //text on spider tower button

    //path of asset to re-create
    private string towerPath = "Assets/Prefabs/Towers/Shock Tower.prefab";

    //change shock tower cost
    public void shockCost(string cost) //take in text input from stat controller
    {
        int.TryParse(cost, out int Cost); //convert string to int
        //GetComponentInParent<SetStats>().shockTower.GetComponent<Tower>().cost = Cost; //sets current cost of tower to new cost

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<Tower>().cost = Cost;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        shockText.text = "Shock" + "\n" + "Tower" + "\n" + "(" + Cost + "G)"; //sets button text
    }

    //change shock range
    public void shockRange(string range)
    {
        float.TryParse(range, out float Range); //convert string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<Tower>().range = Range; //changes prefab tower range

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<Tower>().range = Range;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if (shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 0)
            {
                shockTow.GetComponent<Tower>().range = Range; //assigns the new range value to each tower in active session
            }
        }
    }

    //change shock DPS
    public void shockDPS(string dps)
    {
        float.TryParse(dps, out float DPS);
        //GetComponentInParent<SetStats>().shockTower.GetComponent<ShockTower>().DPS = DPS;

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<ShockTower>().DPS = DPS;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if (shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 0)
            {
                shockTow.GetComponent<ShockTower>().DPS = DPS; //assigns the new DPS value to each tower in active session
            }
        }
    }

    //chagne lvl 2 cost
    public void shockCost2(string cost2)
    {
        int.TryParse(cost2, out int Cost2); //convert string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //sets upgrade 1 cost of tower to new cost

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            shockTow.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //assigns the new upgrade cost to each tower in active session
        }
    }

    //change lvl 2 range
    public void shockRange2(string range2)
    {
        float.TryParse(range2, out float Range2); //convert string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //changes prefab tower lvl 2 range

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if(shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 2
            {
                shockTow.GetComponent<Tower>().range = Range2; //assigns the new range2 value to each tower upgraded lvl 1 tower in active session
            }
            shockTow.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //assigns the new range2 value to each tower in active session
        }
    }

    //change shock lvl 2 fire rate
    public void shockDPS2(string dps2)
    {
        float.TryParse(dps2, out float DPS2); //converts string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<ShockTower>().DPSUpgrades[0] = DPS2; //sets level 2 DPS

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<ShockTower>().DPSUpgrades[0] = DPS2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if (shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 2
            {
                shockTow.GetComponent<ShockTower>().DPS = DPS2; //assigns the new DPS2 value to each tower upgraded lvl 1 tower in active session
            }
            shockTow.GetComponent<ShockTower>().DPSUpgrades[0] = DPS2; //assigns the new fire rate value to each tower in active session
        }
    }

    //change lvl 3 cost
    public void shockCost3(string cost3)
    {
        int.TryParse(cost3, out int Cost3); //convert string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3; //sets upgrade lvl 3 cost of prefab tower to new cost

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            shockTow.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3; //assigns the new upgrade cost to each tower in active session
        }
    }

    //change lvl 3 range
    public void shockRange3(string range3)
    {
        float.TryParse(range3, out float Range3); //convert string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3; //changes prefab tower lvl 3 range

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if (shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //looks to see if active towers are upgraded to level 3
            {
                shockTow.GetComponent<Tower>().range = Range3; //assigns the new range3 value to each lvl 3 tower in active session
            }
            shockTow.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3; //assigns the new range2 value to each tower in active session
        }
    }

    //change shock lvl 3
    public void shockDPS3(string dps3)
    {
        float.TryParse(dps3, out float DPS3); //converts string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<ShockTower>().DPSUpgrades[1] = DPS3; //sets level 3 dps of tower prefab

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<ShockTower>().DPSUpgrades[1] = DPS3;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if (shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //looks to see if active towers are upgraded to level 3
            {
                shockTow.GetComponent<ShockTower>().DPS = DPS3; //assigns the new DPS3 value to each lvl 3 tower in active session
            }
            shockTow.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed = DPS3; //assigns the new dps value to each tower in active session
        }
    }

    //change chain 1 percentage
    public void shockChain1(string percentage)
    {
        float.TryParse(percentage, out float Percentage); //converts string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<ShockTower>().chainDamage1 = Percentage; //sets chain 1 percentage of tower prefab

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<ShockTower>().chainDamage1 = Percentage;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if (shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 2
            {
                shockTow.GetComponent<ShockTower>().chainDamage1 = Percentage; //assigns the new chain 1 percentage value to each tower in active session
            }
            shockTow.GetComponent<ShockTower>().chainDamage1 = Percentage; //assigns the new chain 1 percentage value to each tower in active session
        }
    }

    //change chain 2 percentage
    public void shockChain2(string percentage2)
    {
        float.TryParse(percentage2, out float Percentage2); //converts string to float
        //GetComponentInParent<SetStats>().shockTower.GetComponent<ShockTower>().chainDamage2 = Percentage2; //sets chain 2 percentage of tower prefab

        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<ShockTower>().chainDamage2 = Percentage2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);

        GameObject[] shockTowers = GameObject.FindGameObjectsWithTag("ShockTower"); //finds all shock towers active in session and assigns to array
        foreach (GameObject shockTow in shockTowers)
        {
            if (shockTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //looks to see if active towers are upgraded to level 2
            {
                shockTow.GetComponent<ShockTower>().chainDamage2 = Percentage2; //assigns the new chain 2 percentage value to each tower in active session
            }
            shockTow.GetComponent<ShockTower>().chainDamage2 = Percentage2; //assigns the new chain 2 percentage value to each tower in active session
        }
    }
}
