using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : MonoBehaviour
{
    
    public Meteors meteor; //prefab to spawn
    
    public Transform[] spawnPoint; //array of spawn points
    public float timeBetweenMeteors; //time between meteor spawns
    private float spawnCounter; 

    public int amountToSpawn = 15; //amount of meteors to spwan

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenMeteors;
    }

    // Update is called once per frame
    void Update()
    {

        if (amountToSpawn > 0) //&& LevelManager.instance.levelActive
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenMeteors;
                foreach(Transform spawnPoint in spawnPoint)
                {
                    Instantiate(meteor, spawnPoint);
                }
                

                amountToSpawn--;
            }
        }
    }
}
