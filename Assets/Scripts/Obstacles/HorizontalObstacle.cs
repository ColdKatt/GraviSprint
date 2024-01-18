using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HorizontalObstacle : HorizontalObstacleDependencies, IObstacle
{
    public void Spawn()
    {
        Debug.Log(_obstaclePrefab);
        Debug.Log(_panel);
        var obstacle = GameObject.Instantiate(_obstaclePrefab, _panel.transform);
        var xPosition = Random.Range(_panel.rect.xMin, _panel.rect.xMax);

        obstacle.eulerAngles += Vector3.forward * 90;

        Debug.Log($"{_panel.rect.yMax}:{_panel.rect.yMin}");
        obstacle.anchoredPosition = new Vector2(xPosition, 0);
    }
}
