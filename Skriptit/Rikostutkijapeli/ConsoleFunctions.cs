using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsoleFunctions : MonoBehaviour
{
    [HideInInspector] public int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
