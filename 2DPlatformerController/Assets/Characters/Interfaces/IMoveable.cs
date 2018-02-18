using UnityEngine;
using UnityEditor;

public interface IMoveable
{
    PhysicsObjectBasic GetPhysicsObject();
    MovementAttributes GetMovementAttributes();
}