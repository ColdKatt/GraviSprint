using UnityEngine;

[System.Serializable]
public struct ObstacleTransformData
{
    public Vector3 Position;
    public Quaternion Rotation;

    public ObstacleTransformData(Vector3 position, Quaternion rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    public ObstacleTransformData(Vector3 position, Vector3 rotation)
    {
        Position = position;
        Rotation = Quaternion.Euler(rotation);
    }
}
