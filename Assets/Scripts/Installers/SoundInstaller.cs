using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

[CreateAssetMenu(menuName = "Installer Configs/Sound Config", fileName = "Sound Config")]
public class SoundInstaller : ScriptableObjectInstaller
{
    [SerializeField] private GameObject _soundPrefab;
    [SerializeField] private AudioMixer _mainAudioMixer;

    [Header("Sounds")]
    [SerializeField] private List<Sound> _sounds;

    private ReadOnlyDictionary<SoundType, Sound> _clipsDictionary;

    public override void InstallBindings()
    {
        InitializeDictionary();

        Container.Bind<IReadOnlyDictionary<SoundType, Sound>>().To<ReadOnlyDictionary<SoundType, Sound>>().FromInstance(_clipsDictionary).AsSingle();
        Container.BindInterfacesAndSelfTo<SoundSettings>().AsSingle().WithArguments(_mainAudioMixer);
        Container.Bind<SoundManager>().AsSingle().NonLazy();

        Container.BindFactory<Sound, SoundHandler, SoundHandler.Factory>().FromComponentInNewPrefab(_soundPrefab);
    }

    private void InitializeDictionary()
    {
        var clipsDictionary = new Dictionary<SoundType, Sound>();

        foreach (var sound in _sounds)
        {
            if (clipsDictionary.ContainsKey(sound.Type))
            {
                Debug.LogWarning("[SoundInstaller] Repeated SoundType is detected when dictionary is initializing. Check the Sound Config!");
                continue;
            }
            clipsDictionary.Add(sound.Type, sound);
        }

        _clipsDictionary = new(clipsDictionary);
    }
}