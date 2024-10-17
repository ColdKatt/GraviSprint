using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public struct Sound
{
    public SoundType Type;
    public AudioClip Clip;
    public AudioMixerGroup AudioMixer;

    public bool IsMultiply;
}
