using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class VerticalBottomObstacle : VerticalBottomObstacleDependencies, IObstacle
{
    //[SerializeField] private GameObject _parentObject;

    public void Spawn()
    {
        var obstacle = GameObject.Instantiate(_obstaclePrefab, _panel.transform);
        var xPosition = Random.Range(_panel.rect.xMin, _panel.rect.xMax);

        Debug.Log($"{_panel.rect.yMax}:{_panel.rect.yMin}");
        obstacle.anchoredPosition = new Vector2(xPosition, 0);
    }
}
