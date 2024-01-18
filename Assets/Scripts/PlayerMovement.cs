using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;

    public GameObject _test;

    private Vector2 _roofDirection = Vector2.up;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Touch.Enable();
    }

    private void OnEnable()
    {
        _input.Touch.Teleport.started += OnTouchInput;
    }

    private void OnTouchInput(InputAction.CallbackContext context)
    {
        Reverse();
        LaunchRay();
    }

    private void OnDisable()
    {
        _input.Touch.Teleport.started -= OnTouchInput;
    }

    private void Reverse()
    {
        transform.eulerAngles += Vector3.left * 180;
    }

    private void LaunchRay()
    {
        var hit = Physics2D.Raycast((Vector2)transform.position + _roofDirection, _roofDirection);

        if (hit.collider)
        {
            transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            _roofDirection = _roofDirection == Vector2.up ? Vector2.down : Vector2.up;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
