using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner
{
    private List<IObstacle> obstacles;

    public ObstacleSpawner() 
    {
        obstacles = new List<IObstacle>
        {
            new VerticalBottomObstacle(),
            new HorizontalObstacle(),
            new VerticalTopObstacle()
        };
    }

    public void Spawn()
    {
        obstacles[Random.Range(0, obstacles.Count)].Spawn();
    }
}
