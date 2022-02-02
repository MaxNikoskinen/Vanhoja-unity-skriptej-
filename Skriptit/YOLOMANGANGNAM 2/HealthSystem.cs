using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health = 100;

    public Ammobar healthbarScript;
    public TMP_Text healthStatusText;
    public GameObject deathScreen;
    public GameObject gameUI;
    public GameObject weaponHolder;
    public GameObject crosshairCanvas;

    public Image uiEffect;

    public Color health100;
    public Color health75;
    public Color health50;
    public Color health25;
    public Color health0;

    [HideInInspector] public bool isDead = false;

    [HideInInspector] public int currentHealth;

    private AudioManager audioManagerScript;

    private void Start()
    {
        audioManagerScript = GameObject.FindObjectOfType<AudioManager>();
        currentHealth = health;
        healthbarScript.maximum = health;
        healthbarScript.current = currentHealth;
        healthStatusText.text = currentHealth.ToString() + " %";
    }

    private void Update()
    {
        if(currentHealth <= 100 && currentHealth >= 76)
        {
            uiEffect.color = health100;
        }
        else if(currentHealth <= 75 && currentHealth >= 51)
        {
            uiEffect.color = health75;
        }
        else if(currentHealth <= 50 && currentHealth >= 26)
        {
            uiEffect.color = health50;
        }
        else if(currentHealth <= 25 && currentHealth >= 1)
        {
            uiEffect.color = health25;
        }
        else if(currentHealth <= 0)
        {
            uiEffect.color = health0;
        }


        //Tapa pelaaja kun terveys mennee 0 tai alhaisemmaksi
        if(currentHealth <= 0 && isDead == false)
        {
            Die();
        }
    }

    public void Die()
    {
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isDead = true;
        gameUI.SetActive(false);
        weaponHolder.SetActive(false);
        audioManagerScript.Play("Death Screen Music");
        crosshairCanvas.SetActive(false);
    }
}
