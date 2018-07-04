using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlanetController : MonoBehaviour {

    public GameObject[] planets;

    Queue<GameObject> availablePlanets = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
        availablePlanets.Enqueue(planets[0]);
        availablePlanets.Enqueue(planets[1]);
        availablePlanets.Enqueue(planets[2]);

        InvokeRepeating("movePlanetDown", 0, 20f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void movePlanetDown()
    {
        EnqueuePlanet();
        if (availablePlanets.Count == 0)
            return;

        GameObject aPlanet = availablePlanets.Dequeue();
        aPlanet.GetComponent<Planet>().isMooving = true;
    }

    void EnqueuePlanet()
    {
        foreach (GameObject aPlannet in planets)
        {
            if ((aPlannet.transform.position.y<0) & (!aPlannet.GetComponent<Planet>().isMooving))
            {
                aPlannet.GetComponent<Planet>().ResetPosition();
                availablePlanets.Enqueue(aPlannet);
            }
        }
    }
}
