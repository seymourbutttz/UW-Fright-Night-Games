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
<<<<<<< HEAD
    //visual tower update test - Matt
    
=======
        
>>>>>>> 85656eca0fc0cd89ebef3746e93b184d82c86f59

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    public void UpgradeTower()
    {
<<<<<<< HEAD
        theTower.range = rangeUpgrades[currentRangeUpgrade].amount;
        currentRangeUpgrade++;
<<<<<<< HEAD
        if (currentRangeUpgrade <= 3)
        {
            theTower.GetComponent<ProjectileTower>().model[currentRangeUpgrade - 1].SetActive(false);
            theTower.GetComponent<ProjectileTower>().model[currentRangeUpgrade].SetActive(true);
            if(currentRangeUpgrade == 2)
            {
                theTower.GetComponent<ProjectileTower>().projectiles[1].SetActive(true);
                theTower.GetComponent<ProjectileTower>().projectile = theTower.GetComponent<ProjectileTower>().projectiles[1];
                theTower.GetComponent<ProjectileTower>().firePoint.transform.position = theTower.GetComponent<ProjectileTower>().firePointTwo.transform.position;
                theTower.GetComponent<ProjectileTower>().projectiles[0].SetActive(false);
            }
        }
        
        //visual tower update test - matt. Changes Tower visual on second upgrade
        //if(currentRangeUpgrade == 2 && GetComponent<ProjectileTower>().upgradeLevelOneModel == null)
        //{
          //  currentPos = theTower.transform; //gets towers current position
            //towerUpgrade = GetComponent<ProjectileTower>().upgradeLevelOneModel; //saves the prefab model for upgraded tower
            //UIController.instance.towerUpgradePanel.gameObject.SetActive(false); //closes upgrade panel
            //TowerManager.instance.selectedTowerEffect.SetActive(false); //takes away selected tower effect
            //Destroy(TowerManager.instance.selectedTower.gameObject); //destroys previous tower prefab
            //Instantiate(towerUpgrade, currentPos.position, currentPos.rotation); //places new power prefab
            //UIController.instance.towerUpgradePanel.gameObject.SetActive(true);
            
        //}
        //End Test
=======
        if (currentRangeUpgrade <= 3 && theTower.tag == "ProjectileTower") //if statement controlling visible model for projectile tower.
=======
        theTower.range = towerUpgrades[currentTowerUpgrade].range; //assign range upgrade
        theTower.fireRate = towerUpgrades[currentTowerUpgrade].speed; //assign time between projectiles or affect amount

        if(theTower.tag == "ProjectileTower")
>>>>>>> 2ad54e8495f346e00b2905d851be98ed02a28cb8
        {
            ProjectileUpgrade(); //change tower/projectile models
        }
<<<<<<< HEAD
        
>>>>>>> 85656eca0fc0cd89ebef3746e93b184d82c86f59
        if(currentRangeUpgrade >= rangeUpgrades.Length)
=======
        currentTowerUpgrade++;

        if(currentTowerUpgrade >= towerUpgrades.Length)
>>>>>>> 2ad54e8495f346e00b2905d851be98ed02a28cb8
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

<<<<<<< HEAD
=======
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

>>>>>>> 85656eca0fc0cd89ebef3746e93b184d82c86f59
}

[System.Serializable]
public class UpgradeStage //array of upgrades
{
    //public float amount;
    public float range; //tower range
    public float speed; //tower speed
    public int cost; //cost of tower upgrade
}
