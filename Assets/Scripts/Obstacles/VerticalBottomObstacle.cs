using UnityEngine;

public class VerticalBottomObstacle : VerticalBottomObstacleDependencies, IObstacle
{
    public void Spawn()
    {
        var obstacle = GameObject.Instantiate(_obstaclePrefab, _panel.transform);
        var xPosition = Random.Range(_panel.rect.xMin, _panel.rect.xMax);

        obstacle.anchoredPosition = new Vector2(xPosition, 0);
    }
}
