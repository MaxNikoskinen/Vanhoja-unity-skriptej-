using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject helpScreen;
    public GameObject creditsScreen;
    public GameObject settingsScreen;
    public GameObject backToMenuScreen;
    public GameObject gameUI;
    public GameObject crosshairCanvas;

    [HideInInspector] public bool isPaused;

    private HealthSystem healthSystemScript;
    private AudioManager audioManagerScript;

    private void Start()
    {
        healthSystemScript = GameObject.FindObjectOfType<HealthSystem>();
        audioManagerScript = GameObject.FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && healthSystemScript.isDead == false)
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
        gameUI.SetActive(false);
        audioManagerScript.Play("Pause Screen Music");
        crosshairCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        helpScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        backToMenuScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        gameUI.SetActive(true);
        audioManagerScript.StopPlaying("Pause Screen Music");
        crosshairCanvas.SetActive(true);
    }

    public void CLoseSettingsButton()
    {
        if(healthSystemScript.isDead == false)
        {
            settingsScreen.SetActive(false);
            pauseScreen.SetActive(true);

        }
        else if(healthSystemScript.isDead == true)
        {
            settingsScreen.SetActive(false);
            healthSystemScript.deathScreen.SetActive(true);
        }
    }

    public void DIsableDeathScreen()
    {
        healthSystemScript.deathScreen.SetActive(false);
    }
}
