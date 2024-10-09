using UnityEngine;
using Zenject;

public class ObstacleSpawnerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _obstaclePrefab;

    private ObstacleTransformData[] _obstacleDatas =
    {
        new(new Vector3(6, -3.8f, 3), new Vector3(0, 0, 0)),
        new(new Vector3(6, 5.8f, 3), new Vector3(180, 0, 0)),
        new(new Vector3(6, 1, 3), new Vector3(0, 0, 90))
    };

    public override void InstallBindings()
    {
        Container.BindFactory<ObstacleTransformData, Obstacle, Obstacle.Factory>()
                 .FromComponentInNewPrefab(_obstaclePrefab);

        Container.BindInterfacesAndSelfTo<ObstacleSpawner>().AsSingle().WithArguments(_obstacleDatas);
    }
}