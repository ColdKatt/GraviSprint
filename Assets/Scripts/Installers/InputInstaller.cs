using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private Player _player;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_player);
        Container.Bind<Input>().AsSingle();
    }
}