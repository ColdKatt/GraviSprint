using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnObstacleHit;

    public void ChangeGravity()
    {
        LaunchRay();
        Reverse();
    }

    private void Reverse()
    {
        transform.eulerAngles += Vector3.left * 180;
    }

    private void LaunchRay()
    {
        if (Physics.Raycast(transform.position, transform.up * 20, out RaycastHit hit))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnObstacleHit?.Invoke();
    }
}
