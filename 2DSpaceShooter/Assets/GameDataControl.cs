using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataControl : MonoBehaviour {

	// Use this for initialization
	public bool OnePlayerGame;
	public bool TwoPlayerGame;


	void Start () {

		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
