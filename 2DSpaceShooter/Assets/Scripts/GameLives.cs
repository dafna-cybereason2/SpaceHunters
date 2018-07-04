using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLives : MonoBehaviour
{
    Text livesTextUI;
    int lives;
    public int Lives
    {
        get
        {
            return this.lives;
        }
        set
        {
            this.lives = value;
            UpdateLivesTextUI();
        }
    }
    // Use this for initialization
    void Start()
    {
        livesTextUI = GetComponent<Text>();
    }
    void UpdateLivesTextUI()
    {
        string livesStr = string.Format("{0:0000000}", lives);
        livesTextUI.text = livesStr;

    }

}


