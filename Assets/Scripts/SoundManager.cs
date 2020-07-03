using System;
using UnityEngine;

[Serializable]
public class SoundManager : MonoBehaviour
{
    internal static bool soundOn;

    private Animator animator;
    
    void Start()
    {
        soundOn = true;
        animator = GetComponent<Animator>();


    }

    public void ChangeSoundPreference()
    {
        soundOn = soundOn ? false : true;
        animator.SetBool("SoundOn", soundOn);
    }

}
