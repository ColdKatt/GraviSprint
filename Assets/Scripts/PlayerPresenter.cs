using System;
using Zenject;

public class PlayerPresenter : IInitializable, IDisposable
{
    private readonly PlayerInputSystem _input;

    private readonly Player _player;
    private readonly PlayerView _playerView;

    private readonly EnvironmentMovement _envMovement;
    private readonly EndWindowView _endWindowView;

    private readonly ScoreModel _scoreModel;

    public PlayerPresenter(Player player, PlayerView playerView, EnvironmentMovement envMovement, EndWindowView endWindowView, PlayerInputSystem input, ScoreModel scoreModel)
    {
        _player = player;
        _playerView = playerView;
        _envMovement = envMovement;
        _endWindowView = endWindowView;
        _input = input;
        _scoreModel = scoreModel;
    }

    public void Dispose()
    {
        _player.OnObstacleHit -= () => _playerView.SetDeathSound();
        _player.OnObstacleHit -= () => _playerView.SetPlayerAnimation("Death");
        _player.OnObstacleHit -= () => _envMovement.StopMovement();
        _player.OnObstacleHit -= () => _endWindowView.ShowWindow();
        _player.OnObstacleHit -= () => _input.Dispose();
        _player.OnObstacleHit -= () => _scoreModel.StopCounting();
        _player.OnObstacleHit -= () => _scoreModel.Save();
    }

    public void Initialize()
    {
        _player.OnObstacleHit += () => _playerView.SetDeathSound();
        _player.OnObstacleHit += () => _playerView.SetPlayerAnimation("Death");
        _player.OnObstacleHit += () => _envMovement.StopMovement();
        _player.OnObstacleHit += () => _endWindowView.ShowWindow();
        _player.OnObstacleHit += () => _input.Dispose();
        _player.OnObstacleHit += () => _scoreModel.StopCounting();
        _player.OnObstacleHit += () => _scoreModel.Save();
    }
}
