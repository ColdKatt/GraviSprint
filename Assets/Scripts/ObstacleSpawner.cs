using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<IObstacle> obstacles;

    private void Awake()
    {
        obstacles = new List<IObstacle>();
    }

    private void Start()
    {
        obstacles.Add(new VerticalBottomObstacle());
        obstacles.Add(new HorizontalObstacle());
        obstacles.Add(new VerticalTopObstacle());
    }

    public void Spawn()
    {
        obstacles[Random.Range(0, obstacles.Count)].Spawn();
    }
}
