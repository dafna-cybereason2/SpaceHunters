using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Game objects
    public GameObject playButton;
    public GameObject playerShip;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

	// Use this for initialization
	void Start ()
    {
        GMState = GameManagerState.Opening;
	}
	
	// Update game manager state
	void UpdateGameManagerState ()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                break;
            case GameManagerState.Gameplay:
                //hide play button
                playButton.SetActive(false);

                //set player ship visible
                playerShip.GetComponent<PlayerControl>().Init();

                break;
            case GameManagerState.GameOver:
                break;
        }
	}

    //Set game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    
    //will be called when user clicks play
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }
}
