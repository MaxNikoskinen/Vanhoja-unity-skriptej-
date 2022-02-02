using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    AudioManager audioManagerScript;

    private void Start()
    {
        audioManagerScript = FindObjectOfType<AudioManager>();
        audioManagerScript.Play("Menu Music");
    }
}
