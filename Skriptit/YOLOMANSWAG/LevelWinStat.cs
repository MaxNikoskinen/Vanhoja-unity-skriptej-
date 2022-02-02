using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWinStat : MonoBehaviour
{
    [HideInInspector] public int level1Completed;
    [HideInInspector] public int level2Completed;
    [HideInInspector] public int level3Completed;
    [HideInInspector] public int level4Completed;

    private int sceneNumber;

    void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    public void updateStatus()
    {
        if (sceneNumber == 1)
        {
            level1Completed = 1;
            PlayerPrefs.SetInt("Level1Completed", level1Completed);
        }

        else if (sceneNumber == 2)
        {
            level2Completed = 1;
            PlayerPrefs.SetInt("Level2Completed", level2Completed);
        }

        else if (sceneNumber == 3)
        {
            level3Completed = 1;
            PlayerPrefs.SetInt("Level3Completed", level3Completed);
        }

        else if (sceneNumber == 4)
        {
            level4Completed = 1;
            PlayerPrefs.SetInt("Level4Completed", level4Completed);
        }
    }
}
