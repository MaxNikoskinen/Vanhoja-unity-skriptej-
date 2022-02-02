using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;

    public GameObject pauseScreen;
    public PlayerMovementCC playerMovementScript;
    public MouseLookCC mouseLookScript;
    public GameObject settingsScreen;
    public GameObject quitScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    //Pysäytä peli
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseScreen.SetActive(true);
        mouseLookScript.allowLooking = false;
        playerMovementScript.allowMovement = false;
    }

    //Jatka peliä
    public void ResumeGame()
    {

        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseScreen.SetActive(false);
        mouseLookScript.allowLooking = true;
        playerMovementScript.allowMovement = true;
        settingsScreen.SetActive(false);
        quitScreen.SetActive(false);
    }
}
