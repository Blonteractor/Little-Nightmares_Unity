using UnityEngine;

public class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;
    public int playerHealth;

    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }

    public PointInTime(Vector3 _position, Quaternion _rotation, int _playerHealth)
    {
        position = _position;
        rotation = _rotation;
        playerHealth = _playerHealth;
    }

    public PointInTime(int _playerHealth)
    {
        playerHealth = _playerHealth;
    }
}
