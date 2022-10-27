using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Tower theTower;
    
    //Array of models for tower GameObject
    public GameObject[] model; //Array of models for tower object
    public GameObject[] projectiles; //Array of projectile models for tower object.
    
    [HideInInspector]
    public GameObject activeProjectile;
    public Transform firePoint;
    public Transform firePointTwo; //new firepoint for range upgrades
    //public float timeBetweenShots = 1f;
    private float shotCounter;

    private Transform target;
    public Transform launcherModel;

    //public GameObject shotEffect;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
        //shotCounter = theTower.fireRate;
        projectiles[0].SetActive(true);
        //projectiles[1].SetActive(false);
        activeProjectile = projectiles[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            //launcherModel.LookAt(target);
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation,  Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }
        Debug.Log(shotCounter);
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0 && target != null)
        {
            shotCounter = theTower.fireRate;

            firePoint.LookAt(target);
            Instantiate(activeProjectile, firePoint.position, firePoint.rotation);
            //Instantiate(shotEffect, firePoint.position, firePoint.rotation);
            Debug.Log("Shot fired");
        }
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
                        }
                    }
                }
            }
            else
            {
                target = null;
            }
        }
    }
}
