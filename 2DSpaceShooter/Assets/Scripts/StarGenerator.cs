using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {
    public GameObject startGO;
    public int MaxStars;

    Color[] startColors =
    {
        new Color (0.5f,0.5f, 1f), //blue
        new Color (0f,1f, 1f), // green
        new Color (1f,1f, 0), //yellow
        new Color (1f,0, 0) //red
    };
	// Use this for initialization
	void Start () {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i=0; i<MaxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(startGO);
            star.GetComponent<SpriteRenderer>().color = startColors[i % startColors.Length];
            star.transform.position = new Vector2(Random.Range (min.x, max.x), Random.Range(min.y, max.y));
            star.GetComponent<star>().speed = -(1f * Random.value + 0.5f);
            star.transform.parent = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
