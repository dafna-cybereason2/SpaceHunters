using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour {
    public GameObject ExplosionGO;
    GameObject LiveUIText;
	GameObject LiveUIText2;
    GameObject scoreUITextGO; /// Refrence to the text UI game object

    float speed;
    // Use this for initialization
    void Start() {
        LiveUIText = GameObject.FindGameObjectWithTag("LivesTextTag");
		LiveUIText2 = GameObject.FindGameObjectWithTag("LivesTextTag2");
        speed = 2f + ((int)(GameManager.GlobalTimer / 30 ));
        if (speed>6)
            speed = 6;
        //Debug.Log("start : "+speed);
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
        // 
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
			if (col.gameObject.name == "PlayerGO") {
            
				PlayExplosion ();
				Destroy (gameObject);
				scoreUITextGO.GetComponent<GameScore> ().Score += 100;

				if (scoreUITextGO.GetComponent<GameScore> ().Score % 1000 == 0) {
					int lives = (int)float.Parse (LiveUIText.GetComponent<Text> ().text.ToString ());
					lives++;
					LiveUIText.GetComponent<Text> ().text = lives.ToString ();
				}
			}
			if (col.gameObject.name == "PlayerGO_2") {

				PlayExplosion ();
				Destroy (gameObject);
				scoreUITextGO.GetComponent<GameScore> ().Score += 100;

				if (scoreUITextGO.GetComponent<GameScore> ().Score % 1000 == 0) {
					int lives = (int)float.Parse (LiveUIText.GetComponent<Text> ().text.ToString ());
					lives++;
					LiveUIText2.GetComponent<Text> ().text = lives.ToString ();
				}
			}

        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }


}

