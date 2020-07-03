using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string THEME_SOUNDTRACK = "ThemeSoundtrack";

    public Sound[] sounds;

    public static AudioManager instance;

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
        Array.ForEach(sounds, sound => AddNewAudioSource(sound));
            
    }

    private void AddNewAudioSource(Sound sound)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.loop = sound.loop;
    }

    public void Start()
    {
        Play(THEME_SOUNDTRACK);
    }

    public void Play(string name)
    {
        Sound targetSound = Array.Find(sounds, item => item.name == name);
        if (targetSound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        // Sound targetSound = Array.Find(sounds, sound => sound.name.Equals(name));
        // Debug.Log(targetSound.name + " value: "+targetSound.source);

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
