using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class SoundSettings : IInitializable
{
    private readonly AudioMixer _audioMixer;
    private readonly string _audioMixerMainGroup = "Master";

    public bool IsMusicEnabled { get => _isMusicEnabled.Value; set => _isMusicEnabled.Value = value; }
    public bool IsSoundEnabled { get => _isSoundsEnabled.Value; set => _isSoundsEnabled.Value = value; }

    private SavableVariable<bool> _isMusicEnabled;
    private SavableVariable<bool> _isSoundsEnabled;

    private Dictionary<string, SavableVariable<float>> _savedParametersDictionary;
    private SavableVariable<HashSet<string>> _mutedGroups;
    

    public SoundSettings(AudioMixer audioMixer)
    {
        _savedParametersDictionary ??= new();

        _mutedGroups ??= new("mutedAudioGroups", loadImmediately: true);
        _mutedGroups.Value ??= new HashSet<string>();

        _audioMixer = audioMixer;
        var audioMixerGroups = _audioMixer.FindMatchingGroups(_audioMixerMainGroup);

        foreach (var group in audioMixerGroups)
        {
            _savedParametersDictionary[group.name] = new(group.name, 1.0f ,loadImmediately: true);
        }


        _isMusicEnabled ??= new("enableMusic", loadImmediately: true);
        _isSoundsEnabled ??= new("enableSound", loadImmediately: true);
    }

    public SavableVariable<float> GetSavedParameter(string groupName) => _savedParametersDictionary[groupName];

    public void MuteGroup(string mixerGroupName, bool isMute)
    {
        var hasGroup = _mutedGroups.Value.Contains(mixerGroupName);
        if (isMute)
        {
            if (!hasGroup)
            {
                _mutedGroups.Value.Add(mixerGroupName);
                _mutedGroups.Save();
            }
        }
        else
        {
            if (hasGroup)
            {
                _mutedGroups.Value.Remove(mixerGroupName);
                _mutedGroups.Save();
            }
        }

        SetVolume(mixerGroupName, _savedParametersDictionary[mixerGroupName].Value);
    }

    public void SetVolume(string mixerGroupName, float volume)
    {
        var cVolume = Mathf.Log10(volume) * 20;

        Debug.Log(cVolume);

        _savedParametersDictionary[mixerGroupName].Value = volume;

        cVolume = _mutedGroups.Value.Contains(mixerGroupName) ? -80.0f : cVolume;

        _audioMixer.SetFloat(mixerGroupName, cVolume);
    }

    public void Initialize()
    {
        foreach (var groupName in _savedParametersDictionary.Keys)
        {
            SetVolume(groupName, _savedParametersDictionary[groupName].Value);
        }
    }
}
