using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    int index = 0;
    public int totalLevels = 4;
    public float y0ffset = 1f;

	// Use this for initialization
	void Start ()
    {
		
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

    }
}
