using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        LevelManager.Instance.LoadLevel(levelName);
    }
}
