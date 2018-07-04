using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour {
    
    /// </summary>
    public GameObject EnemyGO;
    float maxSpawnRateInSec = 5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Function to swap an enemy
    void SpawnEnemy()
    {
        // bottom left point 
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top right left
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        //Schedule spawn
        ScheduledNextEnemySpawn();
    }

    void ScheduledNextEnemySpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRateInSec > 1f)
        {
            spawnInSeconds = Random.Range(1F, maxSpawnRateInSec);
        }
        else
            spawnInSeconds = 1f;
        Invoke("SpawnEnemy", spawnInSeconds);
    }

    //increase enemy spawn rate
    void IncreaseSpawnRate()
     {
        if (maxSpawnRateInSec > 1f)
            maxSpawnRateInSec--;

        if (maxSpawnRateInSec == 1f)
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
