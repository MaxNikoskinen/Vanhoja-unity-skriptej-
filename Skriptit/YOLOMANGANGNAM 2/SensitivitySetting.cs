using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SensitivitySetting : MonoBehaviour
{
    PlayerMovement playerMovementScript;
    public Slider sensitivitySlider;
    public TMP_Text sliderValueText;
    public Slider sensMultiplierSlider;
    public TMP_Text sensMultiplierSliderValueText;

    private void Start()
    {
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovement>();
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 50.00f);
        sensMultiplierSlider.value = PlayerPrefs.GetFloat("SensitivityMultiplier", 1.00f);
        sliderValueText.text = Mathf.Round(sensitivitySlider.value).ToString();
        sensMultiplierSliderValueText.text = Math.Round(sensMultiplierSlider.value, 1).ToString();
    }

    public void ChangeSensitivity(float sensitivity)
    {
        playerMovementScript.sensitivity = sensitivity;
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        sliderValueText.text = Mathf.Round(sensitivitySlider.value).ToString();
    }

    public void ChangeSensitivityMultiplier(float sensMultiplier)
    {
        playerMovementScript.sensMultiplier = sensMultiplier;
        PlayerPrefs.SetFloat("SensitivityMultiplier", sensMultiplier);
        sensMultiplierSliderValueText.text = Math.Round(sensMultiplierSlider.value, 1).ToString();
    }
}
