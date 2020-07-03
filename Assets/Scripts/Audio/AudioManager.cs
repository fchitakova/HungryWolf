using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string THEME_SOUNDTRACK = "ThemeSoundtrack";

    public Sound[] sounds;

    public static AudioManager instance;

    public void Awake()
    {
        EnsureOnlyOneInstanceIsRunning();

        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds)
        {
            addNewAudioSource(sound);
        }
    }

    private void EnsureOnlyOneInstanceIsRunning()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void addNewAudioSource(Sound sound)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.audio;
        sound.source.volume = sound.volume;
        sound.source.loop = sound.loop;
    }

    public void Start()
    {
        Play(THEME_SOUNDTRACK);
    }

    public void Play(string name)
    {
         Debug.Log("Name: "+ name);
         Sound targetSound = Array.Find(sounds, sound => sound.name.Equals(name));
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

        bool shouldMute = (!soundOn);

        Array.ForEach(audioSources, audioSource => audioSource.mute = shouldMute);
    }

    public void Mute()
    {
        foreach (Sound sound in sounds)
        {
            addNewAudioSource(sound);
        }
    }

}
