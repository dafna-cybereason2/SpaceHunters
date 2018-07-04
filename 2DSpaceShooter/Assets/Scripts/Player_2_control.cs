using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_2_control : MonoBehaviour {
	public GameObject PlayerBulletGO; // this is out player bullet prefab
	public GameObject bulletPosition01;
	public GameObject bulletPosition02;
	public Text LiveUIText;

	const int MaxLives = 3; //max lives
	int lives; //current lives

	public float speed;

	public void  Init()
	{
		lives = MaxLives;
		LiveUIText.text = lives.ToString();

		// Reset position to center
		transform.position = new Vector2 (0,0);

		//set this player to active
		gameObject.SetActive(true);

	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//fire when space 
		if (Input.GetKeyDown("space"))
		{
			//init fist bullet
			GameObject buller01 = (GameObject)Instantiate(PlayerBulletGO);
			buller01.transform.position = bulletPosition01.transform.position;

			//init second bullet
			GameObject buller02 = (GameObject)Instantiate(PlayerBulletGO);
			buller02.transform.position = bulletPosition02.transform.position; // set init position
		}
		float x = Input.GetAxisRaw("Horizontal_P2"); // -1/0/1 = left , no input, right
		float y = Input.GetAxisRaw("Vertical_P2");  // -1/0/1 = down, no input , up
		// npw based on the input we compute a direction verctor and we normilaize it to get unit vector

		Vector2 direction = new Vector2(x, y).normalized;

		Move(direction);

	}

	void Move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // botoom left point corner
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top right point corner

		max.x = max.x - 0.225f;
		min.x = min.x - 0.225f;

		max.y = max.y - 0.225f;
		min.y = min.y - 0.225f;

		//get player current position 
		Vector2 pos = transform.position;


		pos += direction * speed * Time.deltaTime;

		// make sure the new position is not outside the screen
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);


		// update the player position
		transform.position = pos;


	}
}
