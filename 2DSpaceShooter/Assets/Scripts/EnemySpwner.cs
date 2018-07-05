using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour {
    
    /// </summary>
    public GameObject EnemyGO;
    public GameObject[] Heads;
    public GameObject[] Malops;
    float maxSpawnRateInSec = 5f;
    float minSpawnRateInSec = 1f;
    float currTime = 0;
    float startTime = 0;
    //static Random rnd = new Random();

    // Use this for initialization
    void Start () {
        startTime = Time.deltaTime;
        currTime = startTime;

    }
	
	// Update is called once per frame
	void Update () {
        currTime = currTime + Time.deltaTime;
        
    }

    //Function to swap an enemy
    void SpawnEnemy()
    {
        // bottom left point 
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top right left
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (currTime > 20)
        {
            int r = Random.Range(0, Heads.Length);
            GameObject anEnemy = (GameObject)Instantiate(Heads[r]);
            anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
        else
        {
            int r = Random.Range(0, Malops.Length);
            GameObject anEnemy = (GameObject)Instantiate(Malops[r]);
            anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
      
       
        //Schedule spawn
        ScheduledNextEnemySpawn();
    }

    void ScheduledNextEnemySpawn()
    {
        float spawnInSeconds;
        //if (minSpawnRateInSec > 0.1)
            minSpawnRateInSec = 0.99f * minSpawnRateInSec;
        //if (maxSpawnRateInSec > 0.3)
            maxSpawnRateInSec = 0.99f * maxSpawnRateInSec;
        

        if (maxSpawnRateInSec > minSpawnRateInSec)
        {
            spawnInSeconds = Random.Range(minSpawnRateInSec, maxSpawnRateInSec);
            //Debug.Log("minSpawnRateInSec, maxSpawnRateInSec, spawnInSeconds: " + minSpawnRateInSec + ", "+ maxSpawnRateInSec + ", "+ spawnInSeconds);

        }
        else
            spawnInSeconds = minSpawnRateInSec;
        Invoke("SpawnEnemy", spawnInSeconds);
    }

    //increase enemy spawn rate
    void IncreaseSpawnRate()
     {
        if (maxSpawnRateInSec > minSpawnRateInSec)
            maxSpawnRateInSec--;

        if (maxSpawnRateInSec == minSpawnRateInSec)
            CancelInvoke("IncreaseSpawnRate");
    }
    //Start enemy spawn
    public void ScheduledEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSec);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
        
    }
    
    //Stop enemny spawn on gameover
    public void UnscheduledEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
