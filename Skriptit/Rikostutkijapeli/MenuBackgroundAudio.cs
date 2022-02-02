using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundAudio : MonoBehaviour
{
    private AudioManager audioManagerScript;

    public string[] backgroundAudios;

    void Start()
    {
        audioManagerScript = GameObject.FindObjectOfType<AudioManager>();

        foreach (string backgroundAudio in backgroundAudios)
        {
            audioManagerScript.Play(backgroundAudio);
        }
    }
}
