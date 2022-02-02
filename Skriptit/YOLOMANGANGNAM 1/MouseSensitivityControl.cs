using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityControl : MonoBehaviour
{
    private MouseLook mouseLookScript;

    public Slider sensitivitySlider;

    private void Start()
    {
        mouseLookScript = GameObject.FindObjectOfType<MouseLook>();
        sensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 125.0f);
    }

    public void SetSensitivity(float sensitivity)
    {
        mouseLookScript.mouseSensitivity = sensitivity;
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    }
}
