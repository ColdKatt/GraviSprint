using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;
    [SerializeField] private RectTransform _obstaclePrefab;
    [SerializeField] private GameObject _parentObject;

    [SerializeField] private List<IObstacle> obstacles;

    private IObstacle TestObstacle = new VerticalObstacle();

    public void Spawn()
    {
        TestObstacle.Spawn();
    }
}
