using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundVolumeController : MonoBehaviour 
{
	[SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1.00f);
    }

    public void SetSoundVolume (float soundVolume)
	{
		mixer.SetFloat ("volumeSound", Mathf.Log10(soundVolume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }
}
