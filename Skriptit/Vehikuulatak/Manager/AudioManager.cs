using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Class for playing sound and music

public class AudioManager : Singleton<AudioManager>
{
    [Header("Mixer")]
    [SerializeField] private AudioMixer Mixer;

    [Header("Music")]
    [SerializeField] private SoundEffect StartingMusic;
    [SerializeField] private AudioSource MusicAS;

    private AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    //Play music when game starts
    private void Start()
    {
        PlayMusicTrack(StartingMusic);
    }

    //Change audiomixer volume
    public void ChangeMixerGroupVolume(string group, float volume)
    {
        Mixer.SetFloat(group, volume);
    }

    //Plays some sound effect only once with given sound effect data and data volume is added to audiosource
    public void PlayClipOnce(SoundEffect effect)
    {
        AS.outputAudioMixerGroup = effect.Mixer;
        AS.PlayOneShot(effect.GetClip(), effect.volume);
    }

    //Plays some sound effect only one with given sound effect data, from given gameobject audiosource
    public void PlayClipOnce(SoundEffect effect, GameObject source)
    {
        // Search source from GameObject "AudioSource"
        AudioSource SourceAS = source.GetComponent<AudioSource>();

        //If audio source component doesn't exist in "source" objektive, create audiosource component for it
        if (SourceAS == null)
            SourceAS = source.AddComponent<AudioSource>();

        SourceAS.outputAudioMixerGroup = effect.Mixer;

        //Set gameobjects audiosource spatialblend to same of "effect"
        SourceAS.spatialBlend = effect.spatialBlend;

        //Play sound effect source from gameobjects audiosource component
        SourceAS.PlayOneShot(effect.GetClip(), effect.volume);
    }

    //Method that plays music
    public void PlayMusicTrack(SoundEffect track)
    {
        MusicAS.outputAudioMixerGroup = track.Mixer;
        MusicAS.clip = track.GetClip();
        MusicAS.volume = track.volume;
        MusicAS.loop = true;
        MusicAS.Play();
    }
}
