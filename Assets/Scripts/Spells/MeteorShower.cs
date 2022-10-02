using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : MonoBehaviour
{
    
    public Meteors meteor; //prefab to spawn
    
    public Transform[] spawnPointOne; //array of spawn points
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
                //foreach(Transform spawnPoint in spawnPointOne)
                //{
                    //Instantiate(meteor, spawnPoint);
                //}
                
                for(int i = 0; i < spawnPointOne.Length; i++)
                {
                    Debug.Log(i);
                    Instantiate(meteor, spawnPointOne[i]);
                    i++;                    
                }

                for (int i = 1; i < spawnPointOne.Length; i++)
                {
                    Debug.Log(i);
                    Instantiate(meteor, spawnPointOne[i]);
                    i++;
                }

                spawnCounter = timeBetweenMeteors;
                amountToSpawn--;
            }
        }
    }
}
