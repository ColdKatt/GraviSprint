using TMPro;
using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    [Header("View")]
    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private Animator _endWindowAnimator;
    [SerializeField] private EndWindowData _endWindowData;

    public override void InstallBindings()
    {
        InstallModels();
        InstallViews();
        InstallPresenters();
    }

    private void InstallViews()
    {
        Container.Bind<ScoreView>().AsSingle().WithArguments(_scoreText).NonLazy();

        Container.Bind<EndWindowData>().FromInstance(_endWindowData).AsSingle();
        Container.Bind<EndWindowView>().AsSingle().WithArguments(_endWindowAnimator).NonLazy();
    }

    private void InstallModels()
    {
        Container.BindInterfacesAndSelfTo<ScoreModel>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EndWindowModel>().AsSingle();
    }

    private void InstallPresenters()
    {
        Container.BindInterfacesAndSelfTo<ScorePresenter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EndWindowPresenter>().AsSingle().NonLazy();
    }
}