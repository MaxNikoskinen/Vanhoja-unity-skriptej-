using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundVolumeController : MonoBehaviour 
{
	public AudioMixer mixer;
    public Slider soundSlider;

    void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1.00f);
    }

    public void SetSoundVolume (float soundVolume)
	{
		mixer.SetFloat ("volumeSound", Mathf.Log10(soundVolume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }
}
