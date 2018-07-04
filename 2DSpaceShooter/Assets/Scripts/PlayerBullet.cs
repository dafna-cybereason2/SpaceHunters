using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    float speed;
	// Use this for initialization
	void Start () {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
        // Get the bullets current position
        Vector2 position = transform.position;
        // compute the bullets new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // update the bullet position
        transform.position = position;

        
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top right point corner

        // if the bullet went out of the screen on the top, then destroy the bullet 
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }



    }
}
