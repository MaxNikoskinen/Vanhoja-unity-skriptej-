using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

// Hallitsee käyttöliittymään liittyviä asioita, asetukset ja muut

[RequireComponent(typeof(DontDestroyOnLoad))]
public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text sceneList;
    private bool canLoad;
    [SerializeField] private TMP_InputField SceneInputField;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject gameHud;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text carConditionText;
    [SerializeField] private GameObject playGameScreen;
    private GameObject player;

    private void Update()
    {
        //Lataa skene skenenlatausruudussa
        if(canLoad && Input.GetKeyDown(KeyCode.Return))
        {
            LevelManager.Instance.LoadLevel(SceneInputField.text);
            SceneInputField.text = "";
            SceneInputField.Select();
            SceneInputField.ActivateInputField();
        }
    }

    //Onko pelaaja skenenlatausruudussa
    public void ToggleCanLoad(bool value)
    {
        canLoad = value;
    }

    //Metodi skenenlatausruudun skeneluettelon päivittämiselle
    public void UpdateSceneList(string list)
    {
        sceneList.text = list;
    }

    //Ota pelin pysäytysruutu käyttöön / pois
    public void TogglePauseScreen(bool value)
    {
        pauseScreen.SetActive(value);
    }

    //Ota päävalikko käyttöön / pois
    public void ToggleMainMenuScreen(bool value)
    {
        mainMenuScreen.SetActive(value);
    }

    //Toggles game hud
    public void ToggleGameHud(bool value)
    {
        gameHud.SetActive(value);
    }

    //Update player health in hud
    public void UpdatePlayerHealthUI(int amount)
    {
        player = GameManager.Instance.GetPlayer();

        if(player != null)
        {
            carConditionText.text = amount + "%";
        }
    }

    //Toggles game hud
    public void TogglePlayGameScreen(bool value)
    {
        playGameScreen.SetActive(value);
    }
}


