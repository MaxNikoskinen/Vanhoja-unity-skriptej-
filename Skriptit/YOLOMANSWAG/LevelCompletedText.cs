using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompletedText : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText1;
    [SerializeField] private TMP_Text statusText2;
    [SerializeField] private TMP_Text statusText3;
    [SerializeField] private TMP_Text statusText4;

    private int isCompleted1;
    private int isCompleted2;
    private int isCompleted3;
    private int isCompleted4;

    void Start()
    {
        GetLevel1Status();
        GetLevel2Status();
        GetLevel3Status();
        GetLevel4Status();

        if(isCompleted1 == 1)
        {
            statusText1.text = "TASOA LÄPÄISTY: KYLLÄ";
        }

        if (isCompleted2 == 1)
        {
            statusText2.text = "TASOA LÄPÄISTY: KYLLÄ";
        }

        if (isCompleted3 == 1)
        {
            statusText3.text = "TASOA LÄPÄISTY: KYLLÄ";
        }

        if (isCompleted4 == 1)
        {
            statusText4.text = "TASOA LÄPÄISTY: KYLLÄ";
        }
    }

    private void GetLevel1Status()
    {
        isCompleted1 = PlayerPrefs.GetInt("Level1Completed", 0);
    }

    private void GetLevel2Status()
    {
        isCompleted2 = PlayerPrefs.GetInt("Level2Completed", 0);
    }

    private void GetLevel3Status()
    {
        isCompleted3 = PlayerPrefs.GetInt("Level3Completed", 0);
    }

    private void GetLevel4Status()
    {
        isCompleted4 = PlayerPrefs.GetInt("Level4Completed", 0);
    }
}
