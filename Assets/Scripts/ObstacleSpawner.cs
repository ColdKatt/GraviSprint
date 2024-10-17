using UnityEngine;
using Zenject;

public class ObstacleSpawner : ITickable
{
    public float SpawnRate
    {
        get => _spawnRate;
        private set
        {
            _spawnRate = Mathf.Clamp(value, _minSpawnRate, _maxSpawnRate);
        }
    }

    private readonly Obstacle.Factory _obstacleFactory;
    private readonly ObstacleTransformData[] _obstacleDatas;

    private readonly ScoreModel _scoreModel;

    private float _minSpawnRate = 0.3f;
    private float _maxSpawnRate = 4.0f;

    private float _spawnRate;
    private float _passedTime;

    public ObstacleSpawner(Obstacle.Factory factory, ObstacleTransformData[] obstacleDatas, ScoreModel scoreModel)
    {
        _obstacleFactory = factory;
        _obstacleDatas = obstacleDatas;
        _scoreModel = scoreModel;

        _spawnRate = _maxSpawnRate;
    }

    public void Spawn()
    {
        var randomTransformData = _obstacleDatas[Random.Range(0, _obstacleDatas.Length)];

        _obstacleFactory.Create(randomTransformData);
    }

    public void Tick()
    {
        if (!_scoreModel.IsCounting) return;

        if (_passedTime > _spawnRate)
        {
            Spawn();
            _passedTime = 0;
        }
        else
        {
            _passedTime += Time.deltaTime;
        }

        SpawnRate = _scoreModel.Score > 100 ? _maxSpawnRate - (_maxSpawnRate * (_scoreModel.Score / 1500.0f)) : _maxSpawnRate;
    }
}
