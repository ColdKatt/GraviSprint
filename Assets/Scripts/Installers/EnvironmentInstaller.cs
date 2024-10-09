using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnvironmentInstaller : MonoInstaller
{
    [SerializeField] private Material _bgTopMaterial;
    [SerializeField] private Material _bgBottomMaterial;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EnvironmentMovement>().AsSingle().WithArguments(_bgTopMaterial, _bgBottomMaterial).NonLazy();
    }
}
