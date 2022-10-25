using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockTower : MonoBehaviour
{
    //show tower script

    private Tower theTower; //tower object

    public GameObject[] models; //upgrade levels
    public Transform firePoint; //source for shock effect
    public Transform[] sourceModels; //array of sorce effect models (used to rotate shock effect)
    
    private Transform source;

    public float DPS; //damage per second
    public float[] DPSUpgrades; //upgraded dps values

    public GameObject shockEffect; //visual effect for shocking enemy
    private Transform target; //target location
    private EnemyController targetEnemy; //target enemy
    private EnemyController enemy2, enemy3; //additional enemies

    //[HideInInspector]
    //public List<EnemyController> enemiesInRange = new List<EnemyController>(); //list of enemies within range

    public float chainDamage1; //damage ratio for single chain
    public float chainDamage2; //damage ratio for second chain

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
        source = sourceModels[0]; //base source
    }

    // Update is called once per frame
    void Update()
    {
        
        //if statement looking for closest enemy and assigning it to current enemy
        if (theTower.enemiesUpdated)
        {
            if (theTower.enemiesInRange.Count > 0)
            {
                float minDistance = theTower.range + 1f;
                foreach (EnemyController enemy in theTower.enemiesInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                            targetEnemy = enemy; //assigns current enemy object
                        }
                    }
                }
            }
            else
            {
                target = null;
                targetEnemy = null;
            }
        }
        damageEnemy(); //damages enemy for dps
    }

    //handles enemy damage for shock tower
    public void damageEnemy()
    {
        //if statement rotating source of effect
        if (target != null)
        {
            if(theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 0) //attacks a single enemy
            {
                SingleEnemyAttack();
            }else if (theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //attacks closest enemy and next two closest enemies at reduced damage
            {
                SingleEnemyAttack();
                //ChainAttack();
                
            }
            else if (theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //attacks closest enemy and next four closest enemies at reduced damage
            {
                SingleEnemyAttack();
                //ChainAttack();
                //SecondChainAttack();
            }
            
        }
    }

    //attacks single enemy
    public void SingleEnemyAttack()
    {
        source.rotation = Quaternion.Slerp(source.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime); //rotates towards enemy
        source.rotation = Quaternion.Euler(0f, source.rotation.eulerAngles.y, 0f); //slowly rotates doesnt snap
        targetEnemy.GetComponent<EnemyHealthController>().TakeDamage(DPS * Time.deltaTime); //attacks enemy
    }

    //deals damage to enemies attached to first chain of tower
    public void ChainAttack()
    {
        enemy2.GetComponent<EnemyHealthController>().TakeDamage(DPS * chainDamage1 * Time.deltaTime);
        Debug.Log(theTower.enemiesInRange.Count);
        Debug.Log(targetEnemy.GetComponent<EnemyHealthController>().totalHealth + ", " + enemy2.GetComponent<EnemyHealthController>().totalHealth);
    }

    //deals damage to enemies attached to the second chain of tower
    public void SecondChainAttack()
    {
        if (theTower.enemiesInRange.Count > 3)
        {
            enemy3.GetComponent<EnemyHealthController>().TakeDamage(DPS * chainDamage2 * Time.deltaTime);
        }
    }
}
