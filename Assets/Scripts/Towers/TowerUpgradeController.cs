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
    //visual tower update test - Matt
    //private float rangeNew;
    //private float fireRateNew;
    //private int newCost;
    //private Tower towerUpgrade;
    //private Transform currentPos;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    public void UpgradeRange()
    {
        theTower.range = rangeUpgrades[currentRangeUpgrade].amount;
        currentRangeUpgrade++;
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

}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public int cost;
}
