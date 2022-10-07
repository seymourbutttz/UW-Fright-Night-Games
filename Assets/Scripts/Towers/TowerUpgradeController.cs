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
        

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    public void UpgradeRange()
    {
        theTower.range = rangeUpgrades[currentRangeUpgrade].amount;
        currentRangeUpgrade++;
        if (currentRangeUpgrade <= 3 && theTower.tag == "ProjectileTower") //if statement controlling visible model for projectile tower.
        {
            ProjectileUpgrade();
        }
        
        if(currentRangeUpgrade >= rangeUpgrades.Length)
        {
            hasRangeUpgrade = false;
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
