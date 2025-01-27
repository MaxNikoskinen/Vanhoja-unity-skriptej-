﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//FPS-rajoitin jonka voi ottaa käyttöön asetuksista

public class FPSLimiterSetting : MonoBehaviour
{
    public TMP_Dropdown fpsLimiterDropdown;
    private int numberFromPlayerPrefs;

    //Asettaa asetuksen arvoksi sen mikä on tallenettu
    private void Start()
    {
        fpsLimiterDropdown.value = PlayerPrefs.GetInt("FPSLimit", 4);
        GetNumber();
        SetFPSLimit(numberFromPlayerPrefs);
    }

    //Hakee asetuksen arvon muistista
    private void GetNumber()
    {
        numberFromPlayerPrefs = PlayerPrefs.GetInt("FPSLimit", 4);
    }
    
    //Metodi jolla fps-rajoitinta voi muuttaa pelin asetuksista
    public void SetFPSLimit(int fpsLimit)
    {
        if(fpsLimit == 0)
        {
            Application.targetFrameRate = -1;
        }
        else if(fpsLimit == 1)
        {
            Application.targetFrameRate = 30;
        }
        else if(fpsLimit == 2)
        {
            Application.targetFrameRate = 60;
        }
        else if(fpsLimit == 3)
        {
            Application.targetFrameRate = 120;
        }
        else
        {
            Application.targetFrameRate = 240;
        }

        PlayerPrefs.SetInt("FPSLimit", fpsLimit);
    }
}
