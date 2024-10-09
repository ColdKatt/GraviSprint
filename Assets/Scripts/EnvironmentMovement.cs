using UnityEngine;
using Zenject;

public class EnvironmentMovement : IInitializable, ITickable
{
    public float EnvironmentSpeed { get => _environmentSpeed; }

    private readonly ScoreModel _scoreModel;

    private Material _bgTopMaterial;
    private Material _bgBottomMaterial;

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

        _environmentSpeed = 0.1f;
    }

    public void Tick()
    {
        _bgTopMaterial.mainTextureOffset += Vector2.left * _environmentSpeed * Time.deltaTime / 8.0f;
        _bgBottomMaterial.mainTextureOffset += Vector2.right * _environmentSpeed * Time.deltaTime / 8.0f;

        _environmentSpeed = _isMovementStop ? 0 : Mathf.Clamp(_scoreModel.Score / 200.0f, 0.0f, 100.0f);
    }
}