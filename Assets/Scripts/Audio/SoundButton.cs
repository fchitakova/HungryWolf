using System;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
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
        animator.SetBool("SoundOn", soundOn);
        OnSoundOptionChanged?.Invoke(soundOn);
    }

}
