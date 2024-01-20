using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner
{
    private List<IObstacle> _obstacles;

    public ObstacleSpawner() 
    {
        _obstacles = new List<IObstacle>
        {
            new VerticalBottomObstacle(),
            new HorizontalObstacle(),
            new VerticalTopObstacle()
        };
    }

    public void Spawn()
    {
        _obstacles[Random.Range(0, _obstacles.Count)].Spawn();
    }
}
