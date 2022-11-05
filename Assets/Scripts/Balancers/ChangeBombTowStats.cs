using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ChangeBombTowStats : MonoBehaviour
{
    public TMP_Text bombText;
    public GameObject bomb1, bomb2, bomb3;

#if UNITY_EDITOR
    //path of asset to re-create
    private string towerPath = "Assets/Prefabs/Towers/Bomb Tower.prefab";
    private string bombPath1 = "Assets/Prefabs/Projectiles/PumkinBomb.prefab";
    private string bombPath2 = "Assets/Prefabs/Projectiles/PumkinBomb 1.prefab";
    private string bombPath3 = "Assets/Prefabs/Projectiles/PumkinBomb 2.prefab";
#endif

    //change bomb tower cost
    public void bombCost(string cost) //take in text input from stat controller
    {
        int.TryParse(cost, out int Cost); //convert string to int
        GetComponentInParent<SetStats>().bombTower.GetComponent<Tower>().cost = Cost; //sets current cost of tower to new cost

#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<Tower>().cost = Cost;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        bombText.text = "Bomb" + "\n" + "Tower" + "\n" + "(" + Cost + "G)"; //sets button text
    }

    //change bomb range
    public void bombRange(string range)
    {
        float.TryParse(range, out float Range); //convert string to float
        GetComponentInParent<SetStats>().bombTower.GetComponent<Tower>().range = Range; //changes prefab tower range
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<Tower>().range = Range;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            if (bombTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 0)
            {
                bombTow.GetComponent<Tower>().range = Range; //assigns the new range value to each tower in active session
            }
        }
    }

    //change bomb fire rate
    public void bombRate(string rate)
    {
        float.TryParse(rate, out float Rate);
        GetComponentInParent<SetStats>().bombTower.GetComponent<Tower>().fireRate = Rate;
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<Tower>().fireRate = Rate;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            if (bombTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 0)
            {
                bombTow.GetComponent<Tower>().fireRate = Rate; //assigns the new fire rate value to each tower in active session
            }
        }
    }

    //change base damage
    public void bombDamage(string dam)
    {
        float.TryParse(dam, out float Dam); //convert string to float
        bomb1.GetComponent<Bomb>().damageAmount = Dam; //changes prefab damage amount
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject bombOne = PrefabUtility.LoadPrefabContents(bombPath1);
        // Modify Prefab contents.
        bombOne.GetComponent<Bomb>().damageAmount = Dam;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(bombOne, bombPath1, out bool success);
        PrefabUtility.UnloadPrefabContents(bombOne);
#endif
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb1"); //finds all pumpkin seeds active in session and assigns to array
        foreach (GameObject bomb in bombs)
        {
            bomb.GetComponent<Bomb>().damageAmount = Dam; //assigns the new damage value to bomb tower in active session
        }
    }

    //chagne lvl 2 cost
    public void bombCost2(string cost2)
    {
        int.TryParse(cost2, out int Cost2); //convert string to float
        GetComponentInParent<SetStats>().bombTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //sets upgrade1 cost of tower to new cost
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            bombTow.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost = Cost2; //assigns the new upgrade cost to each tower in active session
        }
    }

    //change lvl 2 range
    public void bombRange2(string range2)
    {
        float.TryParse(range2, out float Range2); //convert string to float
        GetComponentInParent<SetStats>().bombTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //changes prefab tower lvl 2 range
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            if(bombTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 2
            {
                bombTow.GetComponent<Tower>().range = Range2; //assigns the new range2 value to each tower upgraded lvl 1 tower in active session
            }
            bombTow.GetComponent<TowerUpgradeController>().towerUpgrades[0].range = Range2; //assigns the new range2 value to each tower in active session
        }
    }

    //change bomb lvl 2 fire rate
    public void bombRate2(string rate2)
    {
        float.TryParse(rate2, out float Rate2); //converts string to float
        GetComponentInParent<SetStats>().bombTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].speed = Rate2; //sets level 2 fire rate
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[0].speed = Rate2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            if (bombTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //looks to see if active towers are upgraded to level 2
            {
                bombTow.GetComponent<Tower>().fireRate = Rate2; //assigns the new range2 value to each tower upgraded lvl 1 tower in active session
            }
            bombTow.GetComponent<TowerUpgradeController>().towerUpgrades[0].speed = Rate2; //assigns the new fire rate value to each tower in active session
        }
    }

    //change lvl 2 damage
    public void bombDamage2(string dam2)
    {
        float.TryParse(dam2, out float Dam2); //convert string to float
        bomb2.GetComponent<Bomb>().damageAmount = Dam2; //changes prefab damage amount
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject bombTwo = PrefabUtility.LoadPrefabContents(bombPath2);
        // Modify Prefab contents.
        bombTwo.GetComponent<Bomb>().damageAmount = Dam2;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(bombTwo, bombPath2, out bool success);
        PrefabUtility.UnloadPrefabContents(bombTwo);
#endif
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb2"); //finds all level 2 bombs active in session and assigns to array
        foreach (GameObject bomb in bombs)
        {
            bomb.GetComponent<Bomb>().damageAmount = Dam2; //assigns the new damage value to each pumpkin active in the session
        }
    }

    //chagne lvl 3 cost
    public void bombCost3(string cost3)
    {
        int.TryParse(cost3, out int Cost3); //convert string to float
        GetComponentInParent<SetStats>().bombTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3; //sets upgrade lvl 3 cost of prefab tower to new cost
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            bombTow.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost = Cost3; //assigns the new upgrade cost to each tower in active session
        }
    }

    //change lvl 3 range
    public void bombRange3(string range3)
    {
        float.TryParse(range3, out float Range3); //convert string to float
        GetComponentInParent<SetStats>().bombTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3; //changes prefab tower lvl 3 range
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            if (bombTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //looks to see if active towers are upgraded to level 3
            {
                bombTow.GetComponent<Tower>().range = Range3; //assigns the new range3 value to each lvl 3 tower in active session
            }
            bombTow.GetComponent<TowerUpgradeController>().towerUpgrades[1].range = Range3; //assigns the new range2 value to each tower in active session
        }
    }

    //change bomb tower lvl 3 fire rate
    public void bombRate3(string rate3)
    {
        float.TryParse(rate3, out float Rate3); //converts string to float
        GetComponentInParent<SetStats>().bombTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed = Rate3; //sets level 3 fire rate of tower prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject tower = PrefabUtility.LoadPrefabContents(towerPath);
        // Modify Prefab contents.
        tower.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed = Rate3;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(tower, towerPath, out bool success);
        PrefabUtility.UnloadPrefabContents(tower);
#endif
        GameObject[] bombTowers = GameObject.FindGameObjectsWithTag("BombTower"); //finds all bomb towers active in session and assigns to array
        foreach (GameObject bombTow in bombTowers)
        {
            if (bombTow.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //looks to see if active towers are upgraded to level 3
            {
                bombTow.GetComponent<Tower>().fireRate = Rate3; //assigns the new range3 value to each lvl 3 tower in active session
            }
            bombTow.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed = Rate3; //assigns the new fire rate value to each tower in active session
        }
    }

    //change lvl 3 damage
    public void bombDamage3(string dam3)
    {
        float.TryParse(dam3, out float Dam3); //convert string to float
        bomb3.GetComponent<Bomb>().damageAmount = Dam3; //changes prefab damage amount
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject bombThree = PrefabUtility.LoadPrefabContents(bombPath3);
        // Modify Prefab contents.
        bombThree.GetComponent<Bomb>().damageAmount = Dam3;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(bombThree, bombPath3, out bool success);
        PrefabUtility.UnloadPrefabContents(bombThree);
#endif
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb3"); //finds all Lvl 3 upgraded bombs active in session and assigns to array
        foreach (GameObject bomb in bombs)
        {
            bomb.GetComponent<Bomb>().damageAmount = Dam3; //assigns the new damage value to each pumpkin active in the session
        }
    }

    //change lvl 1 blast radius
    public void bombRadius1(string radius)
    {
        float.TryParse(radius, out float Radius); //convert string to float
        bomb1.GetComponent<Bomb>().explodeRange = Radius; //changes prefab blast radius
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject bombOne = PrefabUtility.LoadPrefabContents(bombPath1);
        // Modify Prefab contents.
        bombOne.GetComponent<Bomb>().explodeRange = Radius;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(bombOne, bombPath1, out bool success);
        PrefabUtility.UnloadPrefabContents(bombOne);
#endif
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb1"); //finds active bombs at level 1
        foreach (GameObject bomb in bombs)
        {
            bomb.GetComponent<Bomb>().explodeRange = Radius; //assigns new explosion radius to each level 1 bomb in session
        }
    }

    //change lvl 2 blast radius
    public void bombRadius2(string radius)
    {
        float.TryParse(radius, out float Radius); //convert string to float
        bomb2.GetComponent<Bomb>().explodeRange = Radius; //changes prefab blast radius
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject bombTwo = PrefabUtility.LoadPrefabContents(bombPath2);
        // Modify Prefab contents.
        bombTwo.GetComponent<Bomb>().explodeRange = Radius;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(bombTwo, bombPath2, out bool success);
        PrefabUtility.UnloadPrefabContents(bombTwo);
#endif
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb2"); //finds active bombs at level 2
        foreach (GameObject bomb in bombs)
        {
            bomb.GetComponent<Bomb>().explodeRange = Radius; //assigns new explosion radius to each level 1 bomb in session
        }
    }
    
    //change lvl 3 blast radius
    public void bombRadius3(string radius)
    {
        float.TryParse(radius, out float Radius); //convert string to float
        bomb3.GetComponent<Bomb>().explodeRange = Radius; //changes prefab blast radius
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject bombThree = PrefabUtility.LoadPrefabContents(bombPath3);
        // Modify Prefab contents.
        bombThree.GetComponent<Bomb>().explodeRange = Radius;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(bombThree, bombPath3, out bool success);
        PrefabUtility.UnloadPrefabContents(bombThree);
#endif
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb3"); //finds active bombs at level 3
        foreach (GameObject bomb in bombs)
        {
            bomb.GetComponent<Bomb>().explodeRange = Radius; //assigns new explosion radius to each level 1 bomb in session
        }
    }
}
