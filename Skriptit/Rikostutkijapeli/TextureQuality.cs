using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextureQuality : MonoBehaviour 
{
    public TMP_Dropdown textureDropdown;

    private int textureIntConvert;

    private void Start()
    {
        textureDropdown.value = PlayerPrefs.GetInt("TextureQuality", 3);
    }

    public void Texture(int textureInt) //vaihtaa dropdown listan järjestyksen, jotta parhain asetus on alhaalla ja huonoin ylhäällä kuten muissakin dropdowneissa
	{
        if (textureInt == 0)
        {
            textureIntConvert = 3;
        }


        else if (textureInt == 1)
        {
            textureIntConvert = 2;
        }


        else if (textureInt == 2)
        {
            textureIntConvert = 1;
        }


        else if (textureInt == 3)
        {
            textureIntConvert = 0;
        }



		QualitySettings.masterTextureLimit = textureIntConvert;
        PlayerPrefs.SetInt("TextureQuality", textureInt);
    }
}
