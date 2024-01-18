using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Zenject;


public abstract class Obstacle
{
    protected static RectTransform _obstaclePrefab;

    [Inject]
    private void Construct(RectTransform _prefab)
    {
        _obstaclePrefab = _prefab;
    }
    /*
     * Two types of obstacles
     *      Vertical
     *      Horizontal
     * Vertical spawns on player's level
     * Horizontal spawn above player
     * 
     * 
     * 
     * 
    */
}
