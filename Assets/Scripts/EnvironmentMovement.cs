using UnityEngine;
using Zenject;

public class EnvironmentMovement : IInitializable, ITickable
{
    public float EnvironmentSpeed 
    {
        get => _environmentSpeed; 
        private set
        {
            if (_isMovementStop)
            {
                _environmentSpeed = 0;
            }
            else
            {
                _environmentSpeed = Mathf.Clamp(value, _minEnvironmentSpeed, _maxEnvironmentSpeed);
            }
        }
    }

    private readonly ScoreModel _scoreModel;

    private Material _bgTopMaterial;
    private Material _bgBottomMaterial;

    private float _minEnvironmentSpeed = 1.0f;
    private float _maxEnvironmentSpeed = 15.0f;
    private float _environmentSpeed;

    private bool _isMovementStop;

    public EnvironmentMovement(Material bgTopMaterial, Material bgBottomMaterial, ScoreModel scoreModel)
    {
        _bgTopMaterial = bgTopMaterial;
        _bgBottomMaterial = bgBottomMaterial;
        _scoreModel = scoreModel;
    }

    public void StopMovement()
    {
        _isMovementStop = true;
    }

    public void Initialize()
    {
        _bgTopMaterial.mainTextureOffset = Vector2.zero;
        _bgBottomMaterial.mainTextureOffset = Vector2.zero;

        _environmentSpeed = 1f;
    }

    public void Tick()
    {
        _bgTopMaterial.mainTextureOffset += Vector2.left * _environmentSpeed * Time.deltaTime / 8.0f;
        _bgBottomMaterial.mainTextureOffset += Vector2.right * _environmentSpeed * Time.deltaTime / 8.0f;

        EnvironmentSpeed = _scoreModel.Score / 100.0f;
    }
}