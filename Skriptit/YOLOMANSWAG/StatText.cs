using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StatText : MonoBehaviour
{
    [SerializeField] private TMP_Text canJumpText;
    [SerializeField] private TMP_Text isPausedText;
    [SerializeField] private TMP_Text isDeadText;
    [SerializeField] private TMP_Text deathScreenTimerText;
    [SerializeField] private TMP_Text deathScreenCounterText;
    [SerializeField] private TMP_Text levelCompletedText;
    [SerializeField] private TMP_Text moveSpeedXText;
    [SerializeField] private TMP_Text moveSpeedYText;
    [SerializeField] private TMP_Text playerGravityText;
    [SerializeField] private TMP_Text jumpStrength;
    [SerializeField] private TMP_Text playerMassText;
    [SerializeField] private TMP_Text allLevelAttempts;
    [SerializeField] private TMP_Text timescaleText;
    [SerializeField] private TMP_Text musicPitchText;

    private Player playerClass;
    private PauseScreen pauseScreenClass;

    private bool isActive;
    private int loadScreenState;

    private int allAttemptsCount;

    private int currentScene;

    [SerializeField] private GameObject statScreen;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        loadScreenState = PlayerPrefs.GetInt("F2ScreenActive", 0);
        playerClass = GameObject.FindObjectOfType<Player>();
        pauseScreenClass = GameObject.FindObjectOfType<PauseScreen>();
        LoadScreen();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if(!isActive)
            {
                isActive = true;
                statScreen.SetActive(true);
                PlayerPrefs.SetInt("F2ScreenActive", 1);
            }
            else
            {
                isActive = false;
                statScreen.SetActive(false);
                PlayerPrefs.SetInt("F2ScreenActive", 0);
            }
        }


        if (isActive)
        {
            if(currentScene == 1)
            {
                allAttemptsCount = PlayerPrefs.GetInt("Level1Deaths", 0);
            }
            else if(currentScene == 2)
            {
                allAttemptsCount = PlayerPrefs.GetInt("Level2Deaths", 0);
            }
            else if (currentScene == 3)
            {
                allAttemptsCount = PlayerPrefs.GetInt("Level3Deaths", 0);
            }
            else if (currentScene == 4)
            {
                allAttemptsCount = PlayerPrefs.GetInt("Level4Deaths", 0);
            }

            canJumpText.text = "canJump = " + playerClass.canJump.ToString();
            isPausedText.text = "isPaused = " + pauseScreenClass.isActivated.ToString();
            isDeadText.text = "isDead = " + playerClass.gameOver.ToString();
            deathScreenTimerText.text = "deathScreenTimer = " + playerClass.countdownNumber.ToString();
            deathScreenCounterText.text = "deathScreenCounter = " + playerClass.deathTime.ToString();
            levelCompletedText.text = "levelCompleted = " + playerClass.levelCompleted.ToString();
            moveSpeedXText.text = "playerSpeedX = " + playerClass.playerRb.velocity.x.ToString();
            moveSpeedYText.text = "playerSpeedY = " + playerClass.playerRb.velocity.y.ToString();
            playerGravityText.text = "playerGravity = " + playerClass.playerRb.gravityScale.ToString();
            jumpStrength.text = "jumpStrength = " + playerClass.jumpStrength.ToString();
            playerMassText.text = "playerMass = " + playerClass.playerRb.mass.ToString();
            allLevelAttempts.text = "totalLevelAttempts = " + allAttemptsCount.ToString();
            timescaleText.text = "timescale = " + Time.timeScale.ToString();
            musicPitchText.text = "musicPitch = " + pauseScreenClass.music.pitch.ToString();
        }
    }

    private void LoadScreen()
    {
        if(loadScreenState == 0)
        {
            isActive = false;
            statScreen.SetActive(false);
        }
        else if(loadScreenState == 1)
        {
            isActive = true;
            statScreen.SetActive(true);
        }
    }
}
