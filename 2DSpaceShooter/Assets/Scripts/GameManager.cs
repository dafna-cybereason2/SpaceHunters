using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject scoreUITextGO; /// reference to the score text UI game object
    public static float GlobalTimer;


    //Game objects
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject ScoreText;
    public GameObject player2Ship;
	GameObject GameDataGO;
	bool OnePlayer;
	bool TwoPlayer;
	public bool testmode = false;
	public bool playerOneAlive = true;
	public bool playerTwoAlive = true;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Use this for initialization
    void Start()
    {
        GMState = GameManagerState.Opening;
		GameDataGO = GameObject.FindGameObjectWithTag ("GameData");
        GlobalTimer = 0;
		StartGamePlay ();

    }

    void Update()
    {
        GlobalTimer += Time.deltaTime;
        //Debug.Log("GlobalTimer: "+ GlobalTimer);
		{
			if (playerOneAlive == false && playerTwoAlive == false) {
				SetGameManagerState (GameManager.GameManagerState.GameOver);
				GameDataGO.GetComponent<GameDataControl> ().OnePlayerGame = false;
				GameDataGO.GetComponent<GameDataControl> ().TwoPlayerGame = false;
			}
		}
    }
    // Update game manager state
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                //HIDE game over
                GameOverGO.SetActive(false);

                //play button show
                //playButton.SetActive(true);

                break;
		case GameManagerState.Gameplay:
                //Reset the score 
			scoreUITextGO.GetComponent<GameScore> ().Score = 0;
                //hide play button
			playButton.SetActive (false);

                //set player ship visible
			if (testmode == false) {
				if (GameDataGO.GetComponent<GameDataControl> ().OnePlayerGame == true) {
					playerTwoAlive = false;
					playerShip.GetComponent<PlayerControl> ().Init ();
					GameDataGO.GetComponent<GameDataControl> ().OnePlayerGame = false;
					playerTwoAlive = false;

				}
				if (GameDataGO.GetComponent<GameDataControl> ().TwoPlayerGame) {
					playerShip.GetComponent<PlayerControl> ().Init ();
					player2Ship.GetComponent<Player2Control> ().Init ();
				}
			} else {
				playerShip.GetComponent<PlayerControl> ().Init ();
				player2Ship.GetComponent<Player2Control> ().Init ();
				//GameDataGO.GetComponent<GameDataControl> ().TwoPlayerGame = false;
			}


                //start enemy spawner
                enemySpawner.GetComponent<EnemySpwner>().ScheduledEnemySpawner();

                break;
            case GameManagerState.GameOver:

                //stop enemy
                enemySpawner.GetComponent<EnemySpwner>().UnscheduledEnemySpawner();

                //display game over
                GameOverGO.SetActive(true);

                //load credits scene
                StartCoroutine(LoadLevelDelay(5));

                //change state to opening
                //Invoke("ChangeToOpeningState", 5f);

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

    //Game manager state to opening
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);

    }
    IEnumerator LoadLevelDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Credits");
    }
}
