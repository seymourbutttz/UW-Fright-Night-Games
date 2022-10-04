using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower theTower;

    public UpgradeStage[] rangeUpgrades;
    public int currentRangeUpgrade;
    public bool hasRangeUpgrade = true;

    public UpgradeStage[] firerateUpgrades;
    public int currentFirerateUpgrade;
    public bool hasFirerateUpgrade = true;
    [TextArea]
    public string fireRateText;

    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    public void UpgradeRange()
    {
        theTower.range = rangeUpgrades[currentRangeUpgrade].amount;
        currentRangeUpgrade++;
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
        if (currentRangeUpgrade <= 3 && theTower.tag == "ProjectileTower") //if statement controlling visible model for projectile tower.
        {
            ProjectileUpgrade();
        }
    }

    public void UpgradeFireRate()
    {
        theTower.fireRate = firerateUpgrades[currentFirerateUpgrade].amount;
        currentFirerateUpgrade++;
        if(currentFirerateUpgrade >= firerateUpgrades.Length)
        {
            hasFirerateUpgrade = false;
        }
    }
    //Function controlling projectile tower model upgrades.
    public void ProjectileUpgrade()
    {
        theTower.GetComponent<ProjectileTower>().model[currentRangeUpgrade - 1].SetActive(false); //deactivates the current visible tower model
        theTower.GetComponent<ProjectileTower>().model[currentRangeUpgrade].SetActive(true); //activates the new tower model
        if (currentRangeUpgrade == 2) //if statement to change the projectile model and firepoint position for a taller tower
        {
            theTower.GetComponent<ProjectileTower>().projectiles[1].SetActive(true);
            theTower.GetComponent<ProjectileTower>().projectile = theTower.GetComponent<ProjectileTower>().projectiles[1];
            theTower.GetComponent<ProjectileTower>().firePoint.transform.position = theTower.GetComponent<ProjectileTower>().firePointTwo.transform.position;
            theTower.GetComponent<ProjectileTower>().projectiles[0].SetActive(false);
        }
    }
}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public int cost;
}
