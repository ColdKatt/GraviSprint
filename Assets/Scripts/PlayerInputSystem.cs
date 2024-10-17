using System;
using UnityEngine;
using Zenject;

public class PlayerInputSystem : IInitializable, IDisposable
{
    private Player _player;
    private PlayerInput _input;

    public PlayerInputSystem(Player player)
    {
        _player = player; 
        _input ??= new();
    }

    public void SetEnable(bool isEnable)
    {
        if (isEnable)
        {
            _input.Touch.Enable();

        }
        else
        {
            _input.Touch.Disable();
        }
    }

    public void Initialize()
    {
        _input.Touch.Teleport.started += _ => _player.ChangeGravity();

        SetEnable(true);
    }

    // ??? How is it works ???
    public void Dispose()
    {
        _input.Touch.Teleport.started -= _ => _player.ChangeGravity();

        SetEnable(false);
    }
}
