using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTower : MonoBehaviour
{
    private Tower theTower;

    public Transform effectRing;

    public GameObject slowEffect; // web model
    private Transform target; //target to look at
    public Transform launchermodel; //model look point

    [HideInInspector]
    public List<EnemyController> slowedEnemies = new List<EnemyController>(); //generated webs

    //Array of models for tower GameObject
    public GameObject[] model; //Array of models for tower object

    private float checkCounter; //prevents constant list checking
    public float checkTime = .2f; //time to check

    
    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        //aims the spider at each enemy it "shoots" at. Also activates the web model on each enemy.
        foreach(EnemyController enemy in theTower.enemiesInRange)
        {
            if (!enemy.isSlowed) //makes sure the slow effect does not stack or continuously generate webs
            {
                target = enemy.transform; //enemy position               
                enemy.speedMod = theTower.fireRate; //slows enemy
                enemy.slowEffect.SetActive(true); //activates slow effect on enemy
                slowedEnemies.Add(enemy); //adds slowed enemy to a list of slowed enemies
                enemy.isSlowed = true; //marks the enemy as slowed
            }

            //looks at target 
            if (target != null)
            {
                //launchermodel.LookAt(target);
                launchermodel.rotation = Quaternion.Slerp(launchermodel.rotation, Quaternion.LookRotation(target.position - transform.position), 8f * Time.deltaTime);
                launchermodel.rotation = Quaternion.Euler(0f, launchermodel.rotation.eulerAngles.y, 0f);
            }
                        
        }

        //deactivates web object on enemy once it leaves the tower range
        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;
            ResetEnemy(); //resets enemy
        }
        
        //looks to see if there are any targets in range
        if (theTower.enemiesUpdated && theTower.enemiesInRange.Count <= 0)
        {
            target = null; //empties target when no targets are in range.
        }

        //effect ring size
        effectRing.localScale = new Vector3(theTower.range, 1f, theTower.range);
    }

    //removes slow effect once tower is destroyed.
    public void RemoveSlowEffect()
    {
        for (int i = slowedEnemies.Count - 1; i >= 0; i--)
        {
            slowedEnemies[i].slowEffect.SetActive(false); //deactivates slow effect on enemy
            slowedEnemies[i].isSlowed = false; //removes slow condition from enemy
            slowedEnemies[i].speedMod = theTower.fireRate / theTower.fireRate; //resets the slow effect once the enemy leaves the towers range.
        }
        slowedEnemies.Clear(); //clears tower's list of slowed enemies.
    }

    //resets enemy by removing slow effect visual and removing the 'slowness' from the enemy
    public void ResetEnemy()
    {
        for (int i = slowedEnemies.Count - 1; i >= 0; i--)
        {
            float distance = Vector3.Distance(transform.position, slowedEnemies[i].transform.position); //checks distance between tower's model and slowed enemy in list
            if (distance > theTower.range + .5f && slowedEnemies.Count > 0) //enters if distance is outside of tower range
            {
                slowedEnemies[i].slowEffect.SetActive(false); //deactivates slow effect on enemy
                slowedEnemies[i].isSlowed = false; //removes slow condition from enemy
                slowedEnemies[i].speedMod = theTower.fireRate / theTower.fireRate; //resets the slow effect once the enemy leaves the towers range.;
                slowedEnemies.Remove(slowedEnemies[i]); //removes enemy from list of tower's slowed enemies.
            }
        }
    }
}
