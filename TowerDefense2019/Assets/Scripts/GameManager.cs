using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    [SerializeField] private GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            if (GameIsOver)
            {
                return;
            }



            EndGame();

        }	
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over!");

    }
}

