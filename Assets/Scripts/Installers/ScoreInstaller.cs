using TMPro;
using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    [SerializeField] private TMP_Text _scoreText;

    [Header("Sync")]
    [SerializeField] private TMP_Text _currentScoreText;
    [SerializeField] private TMP_Text _highscoreText;

    public override void InstallBindings()
    {
        Container.Bind<TMP_Text>().FromInstance(_scoreText);
        Container.Bind<ITickable>().To<Scoring>().AsSingle().NonLazy();

        InstallSyncTextScore();
    }

    private void InstallSyncTextScore()
    {
        Container.Bind<TMP_Text>().WithId("Current").FromInstance(_currentScoreText);
        Container.Bind<TMP_Text>().WithId("Highscore").FromInstance(_highscoreText);
        Container.Bind<TextSync>().AsSingle().NonLazy();
    }
}