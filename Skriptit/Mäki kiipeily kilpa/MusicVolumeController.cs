using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicVolumeController : MonoBehaviour 
{
	public AudioMixer mixer;
    public Slider musicSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.00f);
    }

    public void SetMusicVolume (float musicVolume)
	{
		mixer.SetFloat ("volumeMusic", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
	}
}
