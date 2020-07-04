using System;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    private const string SOUND_ON = "SoundOn";
    internal static bool soundOn;

    private Animator animator;

    public static Action<bool> OnSoundOptionChanged;

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeSoundPreference();
    }

    public void ChangeSoundPreference()
    {
        soundOn = !soundOn;
        animator.SetBool(SOUND_ON, soundOn);
        OnSoundOptionChanged?.Invoke(soundOn);
    }

}
