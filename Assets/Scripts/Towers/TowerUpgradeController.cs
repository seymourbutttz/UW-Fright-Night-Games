using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower theTower;

    //public UpgradeStage[] rangeUpgrades;
    //public int currentRangeUpgrade;
    //public bool hasRangeUpgrade = true;

    //public UpgradeStage[] firerateUpgrades;
    //public int currentFirerateUpgrade;
    //public bool hasFirerateUpgrade = true;

    //Tower Upgrade variables
    public UpgradeStage[] towerUpgrades; //available tower upgrade cost, and changes
    public int currentTowerUpgrade; //current tower upgrade level
    public bool hasTowerUpgrade; //does the tower have another upgrade available?

    [TextArea]
    public string fireRateText;
        

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    public void UpgradeTower()
    {
        theTower.range = towerUpgrades[currentTowerUpgrade].range; //assign range upgrade
        theTower.fireRate = towerUpgrades[currentTowerUpgrade].speed; //assign time between projectiles or affect amount

        if(theTower.tag == "ProjectileTower")
        {
            ProjectileUpgrade(); //change tower/projectile models
        }
        currentTowerUpgrade++;

        if(currentTowerUpgrade >= towerUpgrades.Length)
        {
            hasTowerUpgrade = false; //no tower upgrades available.
        }

    }

    //public void UpgradeRange()
    //{
    //    theTower.range = rangeUpgrades[currentRangeUpgrade].amount;
    //    currentRangeUpgrade++;
    //    if (currentRangeUpgrade <= 3 && theTower.tag == "ProjectileTower") //if statement controlling visible model for projectile tower.
    //    {
    //        ProjectileUpgrade();
    //    }
        
    //    if(currentRangeUpgrade >= rangeUpgrades.Length)
    //    {
    //        hasRangeUpgrade = false;
    //    }
    //}

    //public void UpgradeFireRate()
    //{
    //    theTower.fireRate = firerateUpgrades[currentFirerateUpgrade].amount;
    //    currentFirerateUpgrade++;
    //    if(currentFirerateUpgrade >= firerateUpgrades.Length)
    //    {
    //        hasFirerateUpgrade = false;
    //    }
    //}

    //Function controlling projectile tower model upgrades.
    public void ProjectileUpgrade()
    {
        theTower.GetComponent<ProjectileTower>().model[currentTowerUpgrade].SetActive(false); //deactivates the current visible tower model
        theTower.GetComponent<ProjectileTower>().model[currentTowerUpgrade + 1].SetActive(true); //activates the new tower model
        
        theTower.GetComponent<ProjectileTower>().projectiles[currentTowerUpgrade].SetActive(false); //deactivates current projectile
        theTower.GetComponent<ProjectileTower>().projectiles[currentTowerUpgrade + 1].SetActive(true); //activates new projectile
        theTower.GetComponent<ProjectileTower>().projectile = theTower.GetComponent<ProjectileTower>().projectiles[currentTowerUpgrade + 1]; //assigns new projectile to deal more damage
        if(currentTowerUpgrade == 0) //changes firepoint position with larger model.
        {
            theTower.GetComponent<ProjectileTower>().firePoint.transform.position = theTower.GetComponent<ProjectileTower>().firePointTwo.transform.position;
        }
    }

}

[System.Serializable]
public class UpgradeStage //array of upgrades
{
    //public float amount;
    public float range; //tower range
    public float speed; //tower speed
    public int cost; //cost of tower upgrade
}
