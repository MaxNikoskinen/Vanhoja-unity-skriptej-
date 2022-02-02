using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FPSCounter : MonoBehaviour 
{	
    public TMP_Text fpsCounterText;
	public GameObject m_fpsCounter;
//    public Toggle fpsCounterToggle;

	int frameCount;
	float deltaTime;
	double fps;
	float updateRate = 2.0f;

    void Start()
    {
//        fpsCounterToggle.isOn = PlayerPrefs.GetInt("FPSCounterVisibility") == 1 ? true : false;
    }

    void Update () 
	{
        if(Time.timeScale == 0)
        {
            return;
        }

		frameCount++;
		deltaTime += Time.deltaTime;

		if(deltaTime > 1 / updateRate) 
		{
			fps = Math.Round (frameCount / deltaTime, 0);
			fpsCounterText.text = fps.ToString() + " fps";
			frameCount = 0;
			deltaTime -= 1 / updateRate;
		}
	}

    public void FPSCounterActive(bool counterActive)
    {
        m_fpsCounter.SetActive(counterActive);
//        PlayerPrefs.SetInt("FPSCounterVisibility", counterActive ? 1 : 0);
    }
}
