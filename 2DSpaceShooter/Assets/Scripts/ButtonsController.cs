using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    int index = 0;
    public int totalLevels = 4;
    public float y0ffset = 1f;
	GameObject GameDataOB;


	// reference:
	// index 0 = 1 player
	// index 1 = 2 players
	//index 2 = High Score
	//index 3 = credits


	// Use this for initialization
	void Start ()
    {
		GameDataOB = GameObject.FindGameObjectWithTag ("GameData");
	}
	
	// Update is called once per frame
	void Update ()
    {

        float x = Input.GetAxisRaw("Horizontal"); // -1/0/1 = left , no input, right
        float y = Input.GetAxisRaw("Vertical");

        if ( y == -1 )
        {
            if (index < totalLevels-1)
            {
                index++;
                Vector2 position = transform.position;
                position.y -= y0ffset;
                transform.position = position;
                Debug.Log(transform.position);
                
            }
        }

        if (y == 1)
        {
            if (index >= 1)
            {
                index--;
                Vector2 position = transform.position;
                position.y += y0ffset;
                transform.position = position;
                Debug.Log(transform.position);
            }
        }

		if (Input.GetButtonDown("Fire1") ){
			if (index == 0) {
				GameDataOB.GetComponent<GameDataControl> ().OnePlayerGame = true;
				SceneManager.LoadScene ("SampleScene");
			}
			if (index == 1) {
				GameDataOB.GetComponent<GameDataControl> ().TwoPlayerGame = true;
					SceneManager.LoadScene ("SampleScene");
				}
			if (index == 2) {
				//SceneManager.LoadScene ("SampleScene");
				Debug.Log("No high score yet...");
			}
			if (index == 3) {
				SceneManager.LoadScene("Credits");
			}
    	}
	}
}
