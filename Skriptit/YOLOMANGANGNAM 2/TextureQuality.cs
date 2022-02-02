using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextureQuality : MonoBehaviour 
{
    public TMP_Dropdown textureDropdown;

    private void Start()
    {
        textureDropdown.value = PlayerPrefs.GetInt("TextureQuality", 0);
    }

    public void Texture(int textureInt)
	{
		QualitySettings.masterTextureLimit = textureInt;
        PlayerPrefs.SetInt("TextureQuality", textureInt);
    }
}
