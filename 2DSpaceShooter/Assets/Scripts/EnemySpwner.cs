using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwner : MonoBehaviour {
    
    /// </summary>
    public GameObject EnemyGO;
    float maxSpawnRateInSec = 5f;

    // Use this for initialization
    void Start () {
        Invoke("SpawnEnemy", maxSpawnRateInSec);
		
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
    }
}
