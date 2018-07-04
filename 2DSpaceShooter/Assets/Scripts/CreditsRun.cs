using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsRun : MonoBehaviour
{
    public float y0ffset = 1f;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
   { 
         transform.Translate(Vector2.up * y0ffset * Time.deltaTime);

        if (Input.GetButtonDown("Fire1")) 
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}