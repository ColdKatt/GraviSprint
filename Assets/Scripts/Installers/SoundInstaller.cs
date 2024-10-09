using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installer Configs/Sound Config", fileName = "Sound Config")]
public class SoundInstaller : ScriptableObjectInstaller
{
    [SerializeField] private GameObject _soundPrefab;

    [Header("Sounds")]
    [SerializeField] private List<Sound> _sounds;

    private ReadOnlyDictionary<SoundType, AudioClip> _clipsDictionary;

    public override void InstallBindings()
    {
        InitializeDictionary();

        Container.Bind<IReadOnlyDictionary<SoundType, AudioClip>>().To<ReadOnlyDictionary<SoundType, AudioClip>>().FromInstance(_clipsDictionary).AsSingle();
        Container.Bind<SoundManager>().AsSingle().NonLazy();

        Container.BindFactory<AudioClip, SoundHandler, SoundHandler.Factory>().FromComponentInNewPrefab(_soundPrefab);
    }

    private void InitializeDictionary()
    {
        var clipsDictionary = new Dictionary<SoundType, AudioClip>();

        foreach (var sound in _sounds)
        {
            clipsDictionary.Add(sound.Type, sound.Clip);
        }

        _clipsDictionary = new(clipsDictionary);
    }
}