using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public List<EnemyWave> wavesToSpawn;

    public List<BossWave> bossToSpawn; //list of boss(es) to spawn

    private float spawnCounter;
    public float waitForFirstSpawn;
    public float timeToBossWave; //time after last wave till boss wave

    public Transform spawnPoint;

    public Castle theCastle;
    public Path thePath;

    public bool shouldSpawn = true; //should spawn waves
    public bool bossSpawn = false; //should spawn boss

    public float waveDisplayTime;
    private float waveDisplayCounter;
    private int waveCounter;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = waitForFirstSpawn;
        waveCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                if (wavesToSpawn[0].shouldDisplayWave)
                {
                    wavesToSpawn[0].shouldDisplayWave = false;

                    UIController.instance.waveText.gameObject.SetActive(true);
                    UIController.instance.waveText.text = "Wave " + waveCounter;
                    waveDisplayCounter = waveDisplayTime;
                }

                if (wavesToSpawn.Count > 0)
                {
                    if (wavesToSpawn[0].enemySpawnOrder.Count > 0)
                    {
                        Instantiate(wavesToSpawn[0].enemySpawnOrder[0], spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);

                        spawnCounter = wavesToSpawn[0].timeBetweenSpawns;

                        wavesToSpawn[0].enemySpawnOrder.RemoveAt(0);
                        if (wavesToSpawn[0].enemySpawnOrder.Count == 0)
                        {
                            spawnCounter = wavesToSpawn[0].timeToNextWave;

                            wavesToSpawn.RemoveAt(0);
                            waveCounter++;

                            if (wavesToSpawn.Count == 0)
                            {
                                shouldSpawn = false; //no more waves to spawn
                                bossSpawn = true; //set boss spawn to true. spawn boss next wave
                                spawnCounter = timeToBossWave; //sets spawn counter to boss wave spawn
                            }
                        }
                    }
                }
            }
        }else if(bossSpawn) //spawn boss text and wave
        {
            spawnCounter -= Time.deltaTime; //time to boss spawn
            if (spawnCounter <= 0)
            {
                if (bossToSpawn[0].shouldDisplayWave) //checks to see if wave text should be displayed
                {
                    bossToSpawn[0].shouldDisplayWave = false; //prevents text from being displayed again in same wave
                    //Debug.Log("Boss Text");
                    UIController.instance.waveText.gameObject.SetActive(true); //activates wave text
                    UIController.instance.waveText.text = "Boss Wave"; //assigns wave text
                    waveDisplayCounter = waveDisplayTime; //sets time to display wave
                }

                if (bossToSpawn.Count > 0) //spawns boss as long as there is object in list
                {
                    if (bossToSpawn[0].BossOrder.Count > 0)
                    {
                        Instantiate(bossToSpawn[0].BossOrder[0], spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath); //generates boss

                        spawnCounter = bossToSpawn[0].timeBetweenSpawns; //checks for amount of time between enemy spawns

                        bossToSpawn[0].BossOrder.RemoveAt(0);
                        if (bossToSpawn[0].BossOrder.Count == 0)
                        {
                            spawnCounter = waitForFirstSpawn; //resets spawn counter

                            bossToSpawn.RemoveAt(0); //removes boss from list of spawners
                            //waveCounter++;

                            if (bossToSpawn.Count == 0) //checks to see if list of bosses is empty
                            {
                                bossSpawn = false; //no more bosses to spawn
                            }
                        }
                    }
                }
            }
        }

        if(waveDisplayCounter > 0)
        {
            waveDisplayCounter -= Time.deltaTime;
            if(waveDisplayCounter <= 0)
            {
                UIController.instance.waveText.gameObject.SetActive(false);
            }
        }
    }
}

[System.Serializable]
public class EnemyWave
{
    public List<EnemyController> enemySpawnOrder = new List<EnemyController>(0);
    public float timeBetweenSpawns;
    public float timeToNextWave;
    [HideInInspector]
    public bool shouldDisplayWave = true;
}

[System.Serializable]
//Boss Wave information to assign in inspector
public class BossWave
{
    public List<EnemyController> BossOrder = new List<EnemyController>(0); //creats a list of bosses. Assigned in inspector
    public float timeBetweenSpawns; //time between boss spawns for multiple bosses
    [HideInInspector]
    public bool shouldDisplayWave = true;
}
