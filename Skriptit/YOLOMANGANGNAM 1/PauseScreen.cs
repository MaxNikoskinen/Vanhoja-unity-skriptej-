using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    private PlayerMovement playerMovementScript;

    [HideInInspector] public bool isPaused;

    private void Start()
    {
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerMovementScript.isDead == false)
        {
            if (isPaused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void BackButton()
    {
        if(playerMovementScript.isDead == true)
        {
            playerMovementScript.deathScreen.SetActive(true);
            settingsScreen.SetActive(false);
        }
        else
        {
            pauseScreen.SetActive(true);
            settingsScreen.SetActive(false);
        }
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
