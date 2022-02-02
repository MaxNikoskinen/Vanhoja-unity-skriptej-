using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTime : MonoBehaviour
{
    public float timeValue;
    public bool updateTime = true;


    private float timeValueTwo;
    private float nextTimeToFlash = 0f;

    void Update()
    {
        if(updateTime)
        {
            timeValue = timeValue + Time.deltaTime;
            timeValueTwo = timeValueTwo + Time.deltaTime;

            if(timeValueTwo >= 1)
            {
                UIManager.Instance.FlashText();
                timeValueTwo = 0;
            }
        }

        UIManager.Instance.UpdateTime(timeValue);
    }

    
}
