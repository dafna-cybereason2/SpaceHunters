using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    GameObject scoreUITextGO; /// Refrence to the text UI game object
    float speed;
    // Use this for initialization
    void Start() {
        speed = 2f;
        ////Get the score text UI
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");

    }

    // Update is called once per frame
    void Update() {
        // get eney current location
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        // bottom left point 
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));


        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)

    {
        if ((col.tag == "playerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            scoreUITextGO.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);


        }
    }
    void PlayExplosion()
    { }


}

