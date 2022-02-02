using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShadowQualitySetting : MonoBehaviour 
{
    public TMP_Dropdown shadowDropdown;

    private void Start()
    {
        shadowDropdown.value = PlayerPrefs.GetInt("ShadowQuality", 2);
    }

    public void Shadows(int shadowInt)
	{
		QualitySettings.shadowResolution = (ShadowResolution)shadowInt;
        PlayerPrefs.SetInt("ShadowQuality", shadowInt);
    }
}
