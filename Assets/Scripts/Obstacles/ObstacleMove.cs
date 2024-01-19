using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private float _destroyPosition;

    private void Start()
    {
        _destroyPosition = -500.0f;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * GameRoot.EnvironmentSpeed;

        if (transform.position.x < _destroyPosition)
        {
            Destroy(gameObject);
        }
    }
}
