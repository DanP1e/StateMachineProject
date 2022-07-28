using UnityEngine;

public interface IUnit
{
    Vector3 Position { get; }
    void RotateToPoint(Vector3 point);
    void MoveToPoint(Vector3 point);
}
