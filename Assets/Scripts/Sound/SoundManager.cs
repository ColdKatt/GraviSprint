using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    private SoundHandler.Factory _soundFactory;

    private IReadOnlyDictionary<SoundType, AudioClip> _clipsDictionary;

    public SoundManager(IReadOnlyDictionary<SoundType, AudioClip> clipsDictionary, SoundHandler.Factory soundFactory)
    {
        _clipsDictionary ??= clipsDictionary;
        _soundFactory = soundFactory;
    }

    public SoundHandler CreateSound(SoundType soundType)
    {
        var clip = _clipsDictionary[soundType];
        var soundHandler = _soundFactory.Create(clip);

        return soundHandler;
    }
}
