using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlurSetting : MonoBehaviour
{
    public TMP_Dropdown settingDropdown;

    public Material blurMaterial;
    public Material defaultMaterial;

    public Image[] blurredImages;

    private void Start()
    {
        settingDropdown.value = PlayerPrefs.GetInt("BlurEnabled", 1);
    }

    public void ChangeSetting(int enabled)
    {
        if(enabled == 1)
        {
            foreach (Image blurredImage in blurredImages)
            {
                blurredImage.material = blurMaterial;
            }
        }
        else if(enabled == 0)
        {
            foreach (Image blurredImage in blurredImages)
            {
                blurredImage.material = defaultMaterial;
            }
        }

        PlayerPrefs.SetInt("BlurEnabled", enabled);
    }
}
