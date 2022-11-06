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

    public bool useElectricity = false; //shoot electricity
    public LineRenderer lineRenderer;

    public float DPS; //damage per second
    public float[] DPSUpgrades; //upgraded dps values

    public GameObject shockEffect; //visual effect for shocking enemy
    private Transform target; //target location
    private GameObject targetEnemy = null; //target enemy
    private GameObject enemy2, enemy3; //additional enemies

    private float audioTime = 1; //length of audio file in seconds
    private float audioCounter = 0;

    //[HideInInspector]
    //public List<EnemyController> enemiesInRange = new List<EnemyController>(); //list of enemies within range

    public float chainDamage1; //damage ratio for single chain
    public float chainDamage2; //damage ratio for second chain

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
        source = sourceModels[0]; //base source
        lineRenderer.enabled = false;
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
                        MultipleTargets(); //assigns multiple targets
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                            targetEnemy = enemy.gameObject; //assigns current enemy object
                        }
                    }
                }
            }
            else
            {
                target = null;
                targetEnemy = null;
                enemy2 = null;
                enemy3 = null;
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
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
                Electricity();
            }else if (theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //attacks closest enemy and next two closest enemies at reduced damage
            {
                SingleEnemyAttack();
                ChainAttack();
                Electricity();
            }
            else if (theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //attacks closest enemy and next four closest enemies at reduced damage
            {
                SingleEnemyAttack();
                ChainAttack();
                SecondChainAttack();
                Electricity();
            }
            audioCounter -= Time.deltaTime;
            Debug.Log(audioCounter);
            if (audioCounter <= 0)
            {
                //Debug.Log("Audio play");
                audioCounter = audioTime;
                AudioManager.instance.PlaySFX(11);
            }
        }
    }

    //assign multiple targets
    public void MultipleTargets()
    {
        if (targetEnemy) //checks to make sure the target enemy is not null
        {
            if (theTower.enemiesInRange.Count < 2) { //if the amount of enemies in range is 1, secondary and tertiary targets become null
                enemy2 = null;
                enemy3 = null;
                //Debug.Log(theTower.enemiesInRange.Count);
                if (!enemy2 && !enemy3) { Debug.Log("2 & 3 null"); }
            }else if (theTower.enemiesInRange.Count == 2) //if the number of enemies within range is 2, it will attack the closest at full damage and the furthest at secondary damage
            {
                List<float> dist = new List<float>(); //list of enemy distances to tower
                List<GameObject> enemies = new List<GameObject>(); //list of enemy objects
                foreach (EnemyController enemy in theTower.enemiesInRange) //for each enemy check distance and add distances/enemy objects to respective lists
                {
                    dist.Add(Vector3.Distance(transform.position, enemy.transform.position)); //distance from tower
                    enemies.Add(enemy.gameObject); //enemy associated with distance
                }
                if(dist[0] > dist[1]) //compares distances and assigns closest
                {
                    enemy2 = enemies[0];
                }
                else
                {
                    enemy2 = enemies[1];
                }
                enemy3 = null; //nullifies 3rd enemy
                dist.Clear();
                enemies.Clear();
                Debug.Log("3 null");
            }else if (theTower.enemiesInRange.Count >= 3) //assigns tertiary target if tower is at level 3 and 3 enemies exist
            {
                List<GameObject> targets = IdentifyTwo();
                enemy2 = targets[0];
                enemy3 = targets[1];
                targets.Clear();
                Debug.Log("2 & 3 assigned");
            }
        }
    }

    //identifies 2 enemies closest to target
    private List<GameObject> IdentifyTwo()
    {
        List<GameObject> closestTwo = new List<GameObject>(); //array to return

        int index1 = 0; //location of enemies in list

        List<float> Dist = new List<float>(); //list of enemy distances to tower
        List<GameObject> Enemies = new List<GameObject>(); //list of enemy objects
        foreach (EnemyController enemy in theTower.enemiesInRange) //for each enemy check distance and add distances/enemy objects to respective lists
        {
            Dist.Add(Vector3.Distance(transform.position, enemy.transform.position)); //distance from tower
            Enemies.Add(enemy.gameObject); //enemy associated with distance
        }
        float closest = Dist[0];
        for(int i = 1; i < Dist.Count; i++) //identifies closest enemy
        {
            if (Dist[i] < closest) 
            {
                closest = Dist[i];
                index1 = i;
            }
        }
        Dist.RemoveAt(index1); Enemies.RemoveAt(index1);//removes closest from lists
        index1 = 0; closest = Dist[0];
        for (int i = 1; i < Dist.Count; i++) //identifies second closest enemy
        {
            if (Dist[i] < closest)
            {
                closest = Dist[i];
                index1 = i;
            }
        }
        closestTwo.Add(Enemies[index1]); //assigns to list
        Dist.RemoveAt(index1); Enemies.RemoveAt(index1);
        index1 = 0; closest = Dist[0];
        for (int i = 1; i < Dist.Count; i++) //identifies 3rd closest enemy
        {
            if (Dist[i] < closest)
            {
                closest = Dist[i];
                index1 = i;
            }
        }
        closestTwo.Add(Enemies[index1]); //assigns to list
        Dist.Clear();
        Enemies.Clear();
        return closestTwo;
    }

    //attacks single enemy
    public void SingleEnemyAttack()
    {
        source.rotation = Quaternion.Slerp(source.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime); //rotates towards enemy
        source.rotation = Quaternion.Euler(0f, source.rotation.eulerAngles.y, 0f); //slowly rotates doesnt snap
        targetEnemy.GetComponent<EnemyHealthController>().TakeDamage(DPS * Time.deltaTime); //attacks enemy
        //Electricity();
    }

    //deals damage to enemy attached to first chain of tower
    public void ChainAttack()
    {
        if (enemy2)
        {
            enemy2.GetComponent<EnemyHealthController>().TakeDamage(DPS * chainDamage1 * Time.deltaTime);
            Debug.Log(theTower.enemiesInRange.Count);
            Debug.Log(targetEnemy.GetComponent<EnemyHealthController>().totalHealth + ", " + enemy2.GetComponent<EnemyHealthController>().totalHealth);
        }
    }

    //deals damage to enemy attached to the second chain of tower
    public void SecondChainAttack()
    {
        if (enemy3)
        {
            enemy3.GetComponent<EnemyHealthController>().TakeDamage(DPS * chainDamage2 * Time.deltaTime);
            Debug.Log(targetEnemy.GetComponent<EnemyHealthController>().totalHealth + ", " + enemy2.GetComponent<EnemyHealthController>().totalHealth + ", " + enemy3.GetComponent<EnemyHealthController>().totalHealth);
        }
    }


    //generates electricity effect.
    public void Electricity()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true; //enables line renderer
        }
        lineRenderer.SetPosition(0, firePoint.position); //sets starting position
        lineRenderer.SetPosition(1, targetEnemy.transform.position); //sets end position

        if (enemy2 && theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 1) //creates chain from enemy1 to enemy2
        {
            lineRenderer.positionCount = 4;
            lineRenderer.SetPosition(2, targetEnemy.transform.position);
            lineRenderer.SetPosition(3, enemy2.transform.position);
        }
        else if(enemy3 && theTower.GetComponent<TowerUpgradeController>().currentTowerUpgrade == 2) //creates chain from enemy2 to enemy3
        {
            lineRenderer.positionCount = 6;
            lineRenderer.SetPosition(2, targetEnemy.transform.position);
            lineRenderer.SetPosition(3, enemy2.transform.position);
            lineRenderer.SetPosition(4, enemy2.transform.position);
            lineRenderer.SetPosition(5, enemy3.transform.position);
        }
        else
        {
            lineRenderer.positionCount = 2;
        }
    }
}
