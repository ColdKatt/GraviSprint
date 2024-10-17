using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

public class VolumeInstaller : MonoInstaller
{
    [Header("Audio Mixer Group")]
    [SerializeField] private AudioMixerGroup _mixerGroup;

    [Header("Volume I/O")]
    [SerializeField] private Button _volumeButton;
    [SerializeField] private Slider _volumeSlider;

    [Header("Button Images")]
    [SerializeField] private Sprite _enableImage;
    [SerializeField] private Sprite _disableImage;

    public override void InstallBindings()
    {
        Container.BindInstance(_mixerGroup).AsSingle();
        Container.Bind<VolumeModel>().AsSingle().NonLazy();

        Container.BindInstance(_volumeButton).AsSingle();
        Container.BindInstance(_volumeSlider).AsSingle();
        Container.BindInterfacesAndSelfTo<VolumeView>().AsSingle().WithArguments(_enableImage, _disableImage).NonLazy();

        Container.BindInterfacesAndSelfTo<VolumePresenter>().AsSingle().NonLazy();

    }
}
