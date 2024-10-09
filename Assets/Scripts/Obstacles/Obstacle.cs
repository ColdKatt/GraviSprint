using System;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    private const float DESTROY_X_POSITION = -10.0f;

    private EnvironmentMovement _envMovement;

    [Inject]
    public void Construct(ObstacleTransformData transformData, EnvironmentMovement environmentMovement)
    {
        _envMovement = environmentMovement;

        transform.position = transformData.Position;
        transform.rotation = transformData.Rotation;
    }

    public void Update()
    {
        transform.position += Vector3.left * _envMovement.EnvironmentSpeed * Time.deltaTime;

        if (transform.position.x < DESTROY_X_POSITION)
        {
            Destroy(gameObject);
        }
    }

    public class Factory : PlaceholderFactory<ObstacleTransformData, Obstacle> { }
}