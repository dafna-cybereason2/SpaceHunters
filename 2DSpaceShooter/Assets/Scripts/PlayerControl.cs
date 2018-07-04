using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    GameObject PlayerBulletGO;

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal"); // -1/0/1 = left , no input, right
        float y = Input.GetAxisRaw("Vertical");  // -1/0/1 = down, no input , up
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
