using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F1Screen : MonoBehaviour
{
    [SerializeField] private GameObject f1Screen;
    private bool isOpen;
    private int sceneNumber;
    private int loadScreenState;
    private PauseScreen pauseScreenClass;

    private void Start()
    {
        pauseScreenClass = GameObject.FindObjectOfType<PauseScreen>();
        loadScreenState = PlayerPrefs.GetInt("F1ScreenActive", 0);
        LoadScreen();
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            if(isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void Close()
    {
        f1Screen.SetActive(false);
        isOpen = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        PlayerPrefs.SetInt("F1ScreenActive", 0);
    }

    public void Open()
    {
        f1Screen.SetActive(true);
        isOpen = true;
        PlayerPrefs.SetInt("F1ScreenActive", 1);
    }

    private void LoadScreen()
    {
        if (loadScreenState == 0)
        {
            isOpen = false;
            f1Screen.SetActive(false);
        }
        else if (loadScreenState == 1)
        {
            isOpen = true;
            f1Screen.SetActive(true);
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }

    public void SetTimescale(float newTimescale)
    {
        Time.timeScale = newTimescale;
        pauseScreenClass.music.pitch = newTimescale;
    }
}
