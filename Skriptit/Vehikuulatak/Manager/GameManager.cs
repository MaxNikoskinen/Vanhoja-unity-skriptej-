using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains stuff about common things in the game, like money and player references

[RequireComponent(typeof(DontDestroyOnLoad))]
public class GameManager : Singleton<GameManager>
{
    //Method that can be used to close the game
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        #else
	    	Application.Quit();

        #endif
    }

    private GameObject player;
    private Player playerScript;

    private bool isPaused;
    private bool canPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            //If game is paused
            if (isPaused)
            {
                ResumeGame();
            }
            //If game is not paused
            else
            {
                PauseTheGame();
            }
        }
    }

    //Stop game
    public void PauseTheGame()
    {
        isPaused = true;
        UIManager.Instance.TogglePauseScreen(true);
    }

    //Continue game
    public void ResumeGame()
    {
        isPaused = false;
        UIManager.Instance.TogglePauseScreen(false);
    }

    //Is the player in main menu?
    public void ToggleCanPause(bool value)
    {
        canPause = value;
    }

    //Find player from scene and assign it to reference
    public void FindPlayer(bool find)
    {
        if(find)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Pelaaja: " + player);
        }
        else
        {
            player = null;
        }
    }

    //Get player reference
    public GameObject GetPlayer()
    {
        return player;
    }

    //Find player from scene and assign it to reference
    public void FindPlayerScript(bool find)
    {
        if (find)
        {
            playerScript = FindObjectOfType<Player>();
            Debug.Log("Pelaajaskripti: " + playerScript);
        }
        else
        {
            player = null;
        }
    }

    //Get player reference
    public Player GetPlayerScript()
    {
        return playerScript;
    }
}
