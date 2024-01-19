using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Input : MonoBehaviour
{
    private Player _player;
    private static PlayerInput _input;

    public static void SetEnable(bool condition)
    {
        if (condition)
        {
            _input.Touch.Enable();

        }
        else
        {
            _input.Touch.Disable();
        }
    }

    [Inject]
    public void Construct(Player player)
    {
        Debug.Log("Constructed!");
        _player = player;
    }

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Touch.Teleport.started += OnTouchInput;
    }

    private void OnDisable()
    {
        _input.Touch.Teleport.started -= OnTouchInput;
    }

    private void OnTouchInput(InputAction.CallbackContext context)
    {
        _player.Teleport();
    }
}
