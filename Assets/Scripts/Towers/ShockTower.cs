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

    public GameObject shockEffect; //visual effect for shocking enemy
    private Transform target;
    private EnemyController targetEnemy; //target enemy


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
            }
        }

        attackEnemy(); //damages enemy for dps
    }

    //handles enemy damage for shock tower
    public void attackEnemy()
    {
        //if statement rotating source of effect
        if (target != null)
        {
            source.rotation = Quaternion.Slerp(source.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);
            source.rotation = Quaternion.Euler(0f, source.rotation.eulerAngles.y, 0f);
            targetEnemy.GetComponent<EnemyHealthController>().TakeDamage(DPS * Time.deltaTime); //attacks enemy
        }
    }
}
