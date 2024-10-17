using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager
{
    private SoundHandler.Factory _soundFactory;

    private IReadOnlyDictionary<SoundType, Sound> _soundsDictionary;
    private Dictionary<SoundType, SoundHandler> _createdSoundsDictionary;

    public SoundManager(IReadOnlyDictionary<SoundType, Sound> soundsDictionary, SoundHandler.Factory soundFactory, SoundSettings soundSettings)
    {
        _soundsDictionary ??= soundsDictionary;
        _soundFactory = soundFactory;

        _createdSoundsDictionary ??= new();
    }

    public SoundHandler CreateSound(SoundType soundType)
    {
        var sound = _soundsDictionary[soundType];

        if (sound.IsMultiply || !_createdSoundsDictionary.ContainsKey(soundType))
        {
            var soundHandler = _soundFactory.Create(sound);
            _createdSoundsDictionary.Add(soundType, soundHandler);
            soundHandler.OnSoundEnd += () => _createdSoundsDictionary.Remove(soundType);

            return soundHandler;
        }

        return null;
    }
}
