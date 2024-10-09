using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Animator _animator;
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerView>().AsSingle().WithArguments(_animator);
        Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle().NonLazy();
    }
}