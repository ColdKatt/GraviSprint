using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _windowAnim;
    [SerializeField] private Animator _playerAnim;
    private Vector2 _roofDirection = Vector2.up;

    public void Teleport() // for button work
    {
        Reverse();
        LaunchRay();
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
        if (collision.collider.TryGetComponent(out ObstacleMove o))
        {
            GameRoot.PlayerState.ChangeState(new Dead());
        }

        if (GameRoot.PlayerState is Alive) return;

        Debug.Log(collision.gameObject.name);
        _windowAnim.SetBool("IsDead", true);
        _playerAnim.SetBool("IsDead", true);
    }
}
