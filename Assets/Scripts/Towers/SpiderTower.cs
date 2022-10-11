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

    private List<GameObject> webs = new List<GameObject>(); //generated webs

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
        
        foreach(EnemyController enemy in theTower.enemiesInRange)
        {
            if (!enemy.isSlowed) //makes sure the slow effect does not stack or continuously generate webs
            {
                target = enemy.transform; //enemy position               
                enemy.speedMod = theTower.fireRate; //slows enemy
                GameObject effect = Instantiate(slowEffect, enemy.transform); //generates spider web
                webs.Add(effect);
                
                //Debug.Log("slowed");
                enemy.isSlowed = true; //marks the enemy as slowed
                //Debug.Log("Enemy slowed " + enemy.isSlowed);
            }

            //looks at target 
            if (target != null)
            {
                //launchermodel.LookAt(target);
                launchermodel.rotation = Quaternion.Slerp(launchermodel.rotation, Quaternion.LookRotation(target.position - transform.position), 8f * Time.deltaTime);
                launchermodel.rotation = Quaternion.Euler(0f, launchermodel.rotation.eulerAngles.y, 0f);
            }
            //target = null; //empties target
            
        }

        //destroys web object once it leaves the tower range
        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0)
        {
            checkCounter = checkTime; 
            Debug.Log(webs.Count);
            foreach (GameObject web in webs) //cycles through web list
            {
                float distance = Vector3.Distance(transform.position, web.transform.position); //checks distance between tower's model and web model in list
                if (distance > theTower.range + .5f && webs.Count > 0) //enters if distance is outside of tower range
                {
                    Debug.Log("Hello Matt" + distance);
                    Destroy(web);
                    webs.Remove(web);
                    //        webs.Remove(web);
                    //        Destroy(web);
                    //        Debug.Log(webs.Count);
                }
            }
        }


        //looks to see if there are any targets in range
        if (theTower.enemiesUpdated && theTower.enemiesInRange.Count <= 0)
        {
            target = null; //empties target when no targets are in range.
        }

        //effect ring size
        effectRing.localScale = new Vector3(theTower.range, 1f, theTower.range);
    }
}
