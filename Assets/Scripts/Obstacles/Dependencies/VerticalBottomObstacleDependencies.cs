using UnityEngine;
using Zenject;

public class VerticalBottomObstacleDependencies
{
    protected static RectTransform _panel;
    protected static RectTransform _obstaclePrefab;

    [Inject]
    public void Construct([Inject(Id = "Panel")] RectTransform panel, [Inject(Id = "Obstacle")] RectTransform prefab)
    {
        Debug.Log("Dependencies installed!");
        _panel = panel;
        _obstaclePrefab = prefab;
    }
}
