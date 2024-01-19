using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position += Vector3.left * GameRoot.ObstacleSpeed;
    }
}
