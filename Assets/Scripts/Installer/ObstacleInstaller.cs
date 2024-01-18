using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class ObstacleInstaller : MonoInstaller
{
    [SerializeField] private RectTransform _verticalTopPanel;
    [SerializeField] private RectTransform _verticalBottomPanel;
    [SerializeField] private RectTransform _horizontalPanel;

    [SerializeField] private RectTransform _obstaclePrefab;


    public override void InstallBindings()
    {
        InstallVerticalBottomSpawner();
        InstallHorizontalSpawner();
        InstallVerticalTopSpawner();
    }

    private void InstallVerticalBottomSpawner()
    {
        Container.Bind<RectTransform>().WithId("Panel").FromInstance(_verticalBottomPanel).WhenInjectedInto<VerticalBottomObstacleDependencies>();
        Container.Bind<RectTransform>().WithId("Obstacle").FromInstance(_obstaclePrefab).WhenInjectedInto<VerticalBottomObstacleDependencies>();
        Container.Bind<VerticalBottomObstacleDependencies>().AsSingle().NonLazy();
    }

    private void InstallHorizontalSpawner()
    {
        Container.Bind<RectTransform>().WithId("Panel").FromInstance(_horizontalPanel).WhenInjectedInto<HorizontalObstacleDependencies>();
        Container.Bind<RectTransform>().WithId("Obstacle").FromInstance(_obstaclePrefab).WhenInjectedInto<HorizontalObstacleDependencies>();
        Container.Bind<HorizontalObstacle>().AsSingle().NonLazy();
    }

    private void InstallVerticalTopSpawner()
    {
        Container.Bind<RectTransform>().WithId("Panel").FromInstance(_verticalTopPanel).WhenInjectedInto<VerticalTopObstacleDependencies>();
        Container.Bind<RectTransform>().WithId("Obstacle").FromInstance(_obstaclePrefab).WhenInjectedInto<VerticalTopObstacleDependencies>();
        Container.Bind<VerticalTopObstacleDependencies>().AsSingle().NonLazy();
    }
}