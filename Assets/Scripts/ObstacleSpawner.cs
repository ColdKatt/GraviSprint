using UnityEngine;
using Zenject;

public class ObstacleSpawner : ITickable
{
    public float SpawnRate
    {
        get => _spawnRate;
        private set
        {
            _spawnRate = Mathf.Clamp(value, 0.5f, 4.0f);
        }
    }

    private readonly Obstacle.Factory _obstacleFactory;
    private readonly ObstacleTransformData[] _obstacleDatas;

    private readonly ScoreModel _scoreModel;

    private float _spawnRate = 4.0f;
    private float _passedTime;

    public ObstacleSpawner(Obstacle.Factory factory, ObstacleTransformData[] obstacleDatas, ScoreModel scoreModel)
    {
        _obstacleFactory = factory;
        _obstacleDatas = obstacleDatas;
        _scoreModel = scoreModel;
    }

    public void Spawn()
    {
        var randomTransformData = _obstacleDatas[Random.Range(0, _obstacleDatas.Length)];

        _obstacleFactory.Create(randomTransformData);
    }

    public void Tick()
    {
        if (_passedTime > _spawnRate)
        {
            Spawn();
            _passedTime = 0;
        }
        else
        {
            _passedTime += Time.deltaTime;
        }

        SpawnRate = _scoreModel.Score > 100 ? 4.0f - (3.55f * (_scoreModel.Score / 650.0f)) : 4.0f;
    }
}
