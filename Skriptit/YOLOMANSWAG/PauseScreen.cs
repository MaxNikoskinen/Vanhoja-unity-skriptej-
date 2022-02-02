using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [HideInInspector] public bool isActivated = false;
    private int sceneNumber;
    public GameObject pauseScreen;
    [SerializeField] private GameObject pauseScreenMusic;
    [SerializeField] private GameObject settingsScreen;
    private Player playerClass;
    public AudioSource music;   

    private void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        playerClass = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(playerClass.levelCompleted == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse2))
            {
                if (isActivated == false)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BackToTitleScreen();
        }
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        isActivated = true;
        Time.timeScale = 0;
        music.Pause();
        pauseScreenMusic.SetActive(true);

        if(playerClass.gameOver)
        {
            playerClass.deathScreen.SetActive(false);
            playerClass.deathScreenActive = false;
        }
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        isActivated = false;
        Time.timeScale = 1;
        music.Play();
        settingsScreen.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        pauseScreenMusic.SetActive(false);

        if (playerClass.gameOver)
        {
            playerClass.deathScreen.SetActive(true);
            playerClass.deathScreenActive = true;
        }
    }

    public void BackToTitleScreen()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
