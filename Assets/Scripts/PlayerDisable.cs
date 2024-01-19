using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisable : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Disable()
    {
        _player.gameObject.SetActive(false);
    }
}
