using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string THEME_SOUNDTRACK = "ThemeSoundtrack";

    public Sound[] sounds;

    private static AudioManager instance;
    public void Awake()
    {
        InstantiateAudioManager();
    }

    private void InstantiateAudioManager()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        Play(THEME_SOUNDTRACK);
    }

    
    public void Play(string name)
    {
        Sound targetSound = Array.Find(sounds, item => item.name == name);
        targetSound.source.Play();
    }

    public void OnEnable()
    {
        SoundButton.OnSoundOptionChanged += HandleSoundOption;
    }

    public void OnDisable()
    {
        SoundButton.OnSoundOptionChanged -= HandleSoundOption;
    }

    private void HandleSoundOption(bool soundOn)
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        bool shouldMute = !soundOn;

        Array.ForEach(audioSources, audioSource => audioSource.mute = shouldMute);
    }

}
