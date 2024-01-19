using TMPro;
using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    [SerializeField] private TMP_Text _scoreText;

    public override void InstallBindings()
    {
        Container.Bind<TMP_Text>().FromInstance(_scoreText);
        Container.Bind<ITickable>().To<Scoring>().AsSingle().NonLazy();
    }
}