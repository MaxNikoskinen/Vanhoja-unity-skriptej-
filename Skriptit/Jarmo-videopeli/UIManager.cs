using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject MainMenuScreen;
    [SerializeField] private GameObject LoadSceneScreen;
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject buyScreen;

    [SerializeField] public TMP_Text TimeCounter;
    public Animator textAnim;

    [SerializeField] public TMP_Text MoneyCounter;

    private bool buyScreenActiveweapon;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if(!buyScreenActiveweapon)
            {
                ShowBuyMenu();
            }
            else
            {
                HideBuyMenu();
            }

        }
    }

    public void ShowBuyMenu()
    {
        buyScreen.SetActive(true);
        buyScreenActiveweapon = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideBuyMenu()
    {
        buyScreen.SetActive(false);
        buyScreenActiveweapon = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }








    private string time = "testigang";

    public void UpdateMoney(int amount)
    {
        MoneyCounter.text = "Rahaa: " + amount.ToString() + " | Avaa ostovalikko B-näppäimestä";
    }
    private void Start()
    {
        ToggleUIScreen(true);
    }

    public void ToggleUIScreen(bool value)
    {
        MainMenuScreen.SetActive(value);
    }

    public void FlashText()
    {
        textAnim.Play("SecondGoUp", 0, 0.0f);
    }

    public void RefreshUI()
    {

    }

    public void UpdateTime(float time)
    {

        TimeSpan t = TimeSpan.FromSeconds(time);
        string timeToText = string.Format("{1:D2}.{2:D2}.{3:D3}",
            t.Hours,
            t.Minutes,
            t.Seconds,
            t.Milliseconds);
        TimeCounter.text = timeToText;
    }

    public void TurnOffMenuUI() //load game
    {
        MainMenuScreen.SetActive(false);
        LoadSceneScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        gameUI.SetActive(true);
    }
}
