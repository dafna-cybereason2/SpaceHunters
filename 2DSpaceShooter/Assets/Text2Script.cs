using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text2Script : MonoBehaviour {

	public GameObject GameData;

	// Use this for initialization
	void Start () {

		GameData = GameObject.FindGameObjectWithTag ("GameData");
		if (GameData.GetComponent<GameDataControl> ().TwoPlayerGame == false) {
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
