using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

//Allows easy switching between scenes and other scene related stuff

[RequireComponent(typeof(DontDestroyOnLoad))]
public class LevelManager : Singleton<LevelManager>
{
    [System.Serializable]
    public class LevelData
    {
        public string LevelName; 
        public SceneReference Scene;
    }

    private string sceneList;
    [SerializeField] private LevelData MainMenu;
    [SerializeField] private List<LevelData> Levels = new List<LevelData>();

    void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;

        //If main menu scene is not set, alert to console
        if (MainMenu.Scene == null) 
        {
            Debug.LogWarning("No main menu detected");
            return;
        }

        //Loads to main menu when game starts
        LoadMainMenu();

        //Shows scenes in scene loading screen
        UIManager.Instance.UpdateSceneList("");
        foreach (LevelData data in Levels)
        {
            sceneList += ", " + data.LevelName.ToString();
        }
        UIManager.Instance.UpdateSceneList("Main Menu" + sceneList);
    }
    
    //Load scene with it's assigned name
    public void LoadLevel(string name)
    {
        foreach (LevelData data in Levels)
        {
            if(data.LevelName.Equals(name))
            {
                SceneManager.LoadScene(data.Scene);
                return;
            }
            if(name == "Main Menu")
            {
                LoadMainMenu();
            }
        }
    }

    //Method for loading main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu.Scene);
    }

    //Load scene with scene reference
    public void LoadLevel(SceneReference scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Event to know when scene is loaded
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        //Do if in main menu
        if (scene.path == MainMenu.Scene.ScenePath)
        {
            GameManager.Instance.ToggleCanPause(false);
            UIManager.Instance.ToggleMainMenuScreen(true);
            UIManager.Instance.ToggleGameHud(false);
            GameManager.Instance.FindPlayer(false);
            GameManager.Instance.FindPlayerScript(false);
        }
        else //Do if not in main menu
        {
            GameManager.Instance.ToggleCanPause(true);
            UIManager.Instance.ToggleMainMenuScreen(false);
            UIManager.Instance.ToggleGameHud(true);
            GameManager.Instance.FindPlayer(true);
            GameManager.Instance.FindPlayerScript(true);
            UIManager.Instance.TogglePlayGameScreen(false);
        }
    }
}
