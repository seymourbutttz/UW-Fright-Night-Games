using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower theTower;

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

        if (theTower.tag == "ProjectileTower")
        {
            ProjectileUpgrade(); //change tower/projectile models
        }
        else if (theTower.tag == "SlowTower")
        {
            SlowUpgrade(); //change spider model
        }
        else if (theTower.tag == "BombTower")
        {
            BombUpgrade(); //change tower/bomb models
        }
        else if (theTower.tag == "ShockTower")
        {
            ShockUpgrade(); //change shock tower model
        }
        currentTowerUpgrade++;

        if(currentTowerUpgrade >= towerUpgrades.Length)
        {
            hasTowerUpgrade = false; //no tower upgrades available.
        }

    }

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

    //Function controlling spider tower model upgrades.
    public void SlowUpgrade()
    {
        theTower.GetComponent<SpiderTower>().model[currentTowerUpgrade].SetActive(false); //deactivates the current visible tower model
        theTower.GetComponent<SpiderTower>().model[currentTowerUpgrade + 1].SetActive(true); //activates the new tower model
    }

    //function controlling bomb tower model upgrades
    public void BombUpgrade()
    {
        theTower.GetComponent<BombTower>().models[currentTowerUpgrade].SetActive(false); //deactivates the current visible tower model
        theTower.GetComponent<BombTower>().models[currentTowerUpgrade + 1].SetActive(true); //activates the new tower model
        theTower.GetComponent<BombTower>().activeBomb = theTower.GetComponent<BombTower>().theBombs[currentTowerUpgrade + 1]; //changes bomb prefab to adjust damage
    }

    //function controlling shock tower model upgrades
    public void ShockUpgrade()
    {
        if(currentTowerUpgrade == 0)
        {
            theTower.GetComponent<ShockTower>().models[currentTowerUpgrade].SetActive(false); //deactiveates the current visible model
            theTower.GetComponent<ShockTower>().models[currentTowerUpgrade + 1].SetActive(true); //activates new model
        }
        else
        {
            theTower.GetComponent<ShockTower>().models[currentTowerUpgrade + 1].SetActive(true); //activates next tower model
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
