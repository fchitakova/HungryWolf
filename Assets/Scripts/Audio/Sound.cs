using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public AudioClip audio;

    public string name;
    public bool loop;

    [Range(0f,1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;
}
