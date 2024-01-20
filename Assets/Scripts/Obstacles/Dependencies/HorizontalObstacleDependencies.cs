using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HorizontalObstacleDependencies
{
    protected static RectTransform s_panel;
    protected static RectTransform s_obstaclePrefab;

    [Inject]
    public void Construct([Inject(Id = "Panel")] RectTransform panel, [Inject(Id = "Obstacle")] RectTransform prefab)
    {
        Debug.Log("Dependencies installed!");
        s_panel = panel;
        s_obstaclePrefab = prefab;
    }
}
