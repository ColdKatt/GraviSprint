using System;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class VolumeModel
{
    public event Action<bool> OnVolumeMuted;

    public const float VOLUME_SLIDER_MIN_VALUE = 0.0001f; // -80 db

    private readonly AudioMixerGroup _mixerGroup;
    private readonly SoundSettings _soundSettings;

    public float Volume { get => _soundSettings.GetSavedParameter(_mixerGroup.name).Value;}

    public SavableVariable<bool> IsMute;

    public VolumeModel(AudioMixerGroup mixerGroup, SoundSettings soundSettings)
    {
        _mixerGroup = mixerGroup;
        _soundSettings = soundSettings;
        IsMute ??= new($"is{_mixerGroup.name}Mute", loadImmediately: true);
    }

    public void ChangeVolume(float volume)
    {
        _soundSettings.SetVolume(_mixerGroup.name, volume);
    }

    public void MuteVolume()
    {
        IsMute.Value = !IsMute.Value;
        _soundSettings.MuteGroup(_mixerGroup.name, IsMute.Value);

        OnVolumeMuted?.Invoke(IsMute.Value);
    }
}
