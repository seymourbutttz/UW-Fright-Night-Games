using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetStats : MonoBehaviour
{
    public GameObject projectileTower, spiderTower;
    public GameObject spell1, spell2;
    public EnemieStats[] enemies;
    public TMP_InputField startingGold, pumpTowCost, pumpTowRng, pumpTowFR, pumpTowBD, pumpTowL2C, pumpTowL2R, pumpTowL2FR, pumpTowL2D, pumpTowL3C, pumpTowL3R, pumpTowL3FR, pumpTowL3D;
    public TMP_InputField spidTowCost, spidTowRng, spidTowFR, spidTowL2C, spidTowL2R, spidTowL2FR, spidTowL3C, spidTowL3R, spidTowL3FR;
    public TMP_InputField meteorCost, meteorSpnRt, meteorDmg, meteorBR, meteorSpnQ, meteorDrop;

    // Start is called before the first frame update
    void Start()
    {
        startingGold.GetComponent<TMP_InputField>().text = MoneyManager.instance.startingMoney.ToString();
        SetPumpkinTower();
        SetSpiderTower();
        SetSpells();
        SetEnemies();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //sets default text for pumpkin tower panel. takes current prefab values and displays them in stat window.
    public void SetPumpkinTower()
    {
        pumpTowCost.text = projectileTower.GetComponent<Tower>().cost.ToString(); //cost
        pumpTowRng.text = projectileTower.GetComponent<Tower>().range.ToString(); //range
        pumpTowFR.text = projectileTower.GetComponent<Tower>().fireRate.ToString(); //fire rate
        pumpTowBD.text = projectileTower.GetComponent<ProjectileTower>().projectiles[0].GetComponent<Projectile>().damageAmount.ToString(); //base damage
        pumpTowL2C.text = projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost.ToString(); //level 2 cost
        pumpTowL2R.text = projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range.ToString(); //level 2 range
        pumpTowL2FR.text = projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].speed.ToString(); //level 2 fire rate
        pumpTowL2D.text = projectileTower.GetComponent<ProjectileTower>().projectiles[1].GetComponent<Projectile>().damageAmount.ToString(); //level 2 damage
        pumpTowL3C.text = projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost.ToString(); //level 3 cost
        pumpTowL3R.text = projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range.ToString(); //level 3 range
        pumpTowL3FR.text = projectileTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed.ToString(); //level 3 fire rate
        pumpTowL3D.text = projectileTower.GetComponent<ProjectileTower>().projectiles[2].GetComponent<Projectile>().damageAmount.ToString(); //level 3 damage
    }

    //sets default text for spider tower panel. takes current prefab values and displays them in stat window.
    public void SetSpiderTower()
    {
        spidTowCost.text = spiderTower.GetComponent<Tower>().cost.ToString(); //cost
        spidTowRng.text = spiderTower.GetComponent<Tower>().range.ToString(); //range
        spidTowFR.text = spiderTower.GetComponent<Tower>().fireRate.ToString(); //fire rate
        spidTowL2C.text = spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].cost.ToString(); //level 2 cost
        spidTowL2R.text = spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].range.ToString(); //level 2 range
        spidTowL2FR.text = spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[0].speed.ToString(); //level 2 speed mod
        spidTowL3C.text = spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].cost.ToString(); //level 3 cost
        spidTowL3R.text = spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].range.ToString(); //level 3 range
        spidTowL3FR.text = spiderTower.GetComponent<TowerUpgradeController>().towerUpgrades[1].speed.ToString(); //level 3 speed mod
    }

    //sets default text for shock tower panel. takes current prefab values and displays them in stat window.
    public void SetShockTower()
    {

    }

    //sets default spell values in spells panel. takes current prefab values and displays them in stat window
    public void SetSpells()
    {
        meteorCost.text = spell1.GetComponent<Spells>().cost.ToString(); //cost
        meteorSpnRt.text = spell1.GetComponent<MeteorShower>().timeBetweenMeteors.ToString(); //spawn rate
        meteorDmg.text = spell1.GetComponent<MeteorShower>().meteorModel.GetComponent<Meteors>().damageAmount.ToString(); //damage amount
        meteorBR.text = spell1.GetComponent<MeteorShower>().meteorModel.GetComponent<Meteors>().blastRadius.ToString(); //blast radius
        meteorSpnQ.text = spell1.GetComponent<MeteorShower>().amountToSpawn.ToString(); //amount of meteors to spawn
        meteorDrop.text = spell1.GetComponent<MeteorShower>().meteorModel.GetComponent<Meteors>().dropSpeed.ToString(); //meteor drop speed
    }

    public void SetEnemies()
    {
        foreach(EnemieStats stat in enemies)
        {
            stat.speed.text = stat.enemy.GetComponent<EnemyController>().moveSpeed.ToString(); //speed text
            stat.attackTime.text = stat.enemy.GetComponent<EnemyController>().timeBetweenAttacks.ToString(); //attack time
            stat.damage.text = stat.enemy.GetComponent<EnemyController>().damagePerAttack.ToString(); //enemy damage
            stat.health.text = stat.enemy.GetComponent<EnemyHealthController>().totalHealth.ToString(); //enemy health
            stat.goldWorth.text = stat.enemy.GetComponent<EnemyHealthController>().moneyOnDeath.ToString(); //gold awarded on death
        }
    }
}

//array of enemy stats to be used for balance controller
[System.Serializable]
public class EnemieStats
{
    public GameObject enemy;
    public TMP_InputField speed, attackTime, damage, health, goldWorth;
}
