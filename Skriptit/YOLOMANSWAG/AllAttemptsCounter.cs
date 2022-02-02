using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllAttemptsCounter : MonoBehaviour
{
    [HideInInspector] public int level1Deaths;
    [HideInInspector] public int level2Deaths;
    [HideInInspector] public int level3Deaths;
    [HideInInspector] public int level4Deaths;
    private int sceneNumber;

    void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;

        GetLevel1Deaths();
        GetLevel2Deaths();
        GetLevel3Deaths();
        GetLevel4Deaths();

        UpdateCounter();
    }

    private void GetLevel1Deaths()
    {
        level1Deaths = PlayerPrefs.GetInt("Level1Deaths", 0);
    }

    private void GetLevel2Deaths()
    {
        level2Deaths = PlayerPrefs.GetInt("Level2Deaths", 0);
    }

    private void GetLevel3Deaths()
    {
        level3Deaths = PlayerPrefs.GetInt("Level3Deaths", 0);
    }

    private void GetLevel4Deaths()
    {
        level4Deaths = PlayerPrefs.GetInt("Level4Deaths", 0);
    }

    public void UpdateCounter()
    {
        if (sceneNumber == 1)
        {
            level1Deaths++;
            PlayerPrefs.SetInt("Level1Deaths", level1Deaths);
        }

        else if (sceneNumber == 2)
        {
            level2Deaths++;
            PlayerPrefs.SetInt("Level2Deaths", level2Deaths);
        }

        else if (sceneNumber == 3)
        {
            level3Deaths++;
            PlayerPrefs.SetInt("Level3Deaths", level3Deaths);
        }

        else if (sceneNumber == 4)
        {
            level4Deaths++;
            PlayerPrefs.SetInt("Level4Deaths", level4Deaths);
        }
    }

    public void LowerCounter()
    {
        if (sceneNumber == 1)
        {
            level1Deaths--;
            PlayerPrefs.SetInt("Level1Deaths", level1Deaths);
        }

        else if (sceneNumber == 2)
        {
            level2Deaths--;
            PlayerPrefs.SetInt("Level2Deaths", level2Deaths);
        }

        else if (sceneNumber == 3)
        {
            level3Deaths--;
            PlayerPrefs.SetInt("Level3Deaths", level3Deaths);
        }

        else if (sceneNumber == 4)
        {
            level4Deaths--;
            PlayerPrefs.SetInt("Level4Deaths", level4Deaths);
        }
    }

    public void ResetCounter()
    {
        if (sceneNumber == 1)
        {
            level1Deaths = 0;
            PlayerPrefs.SetInt("Level1Deaths", level1Deaths);
        }

        else if (sceneNumber == 2)
        {
            level2Deaths = 0;
            PlayerPrefs.SetInt("Level2Deaths", level2Deaths);
        }

        else if (sceneNumber == 3)
        {
            level3Deaths = 0;
            PlayerPrefs.SetInt("Level3Deaths", level3Deaths);
        }

        else if (sceneNumber == 4)
        {
            level4Deaths = 0;
            PlayerPrefs.SetInt("Level4Deaths", level4Deaths);
        }
    }
}
