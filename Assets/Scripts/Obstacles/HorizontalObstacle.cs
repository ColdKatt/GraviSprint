using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HorizontalObstacle : HorizontalObstacleDependencies, IObstacle
{
    public void Spawn()
    {
        var obstacle = GameObject.Instantiate(s_obstaclePrefab, s_panel.transform);
        var xPosition = Random.Range(s_panel.rect.xMin, s_panel.rect.xMax);

        obstacle.eulerAngles += Vector3.forward * 90;

        obstacle.anchoredPosition = new Vector2(xPosition, 0);
    }
}
