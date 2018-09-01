using UnityEngine;

public interface IMoveable
{
    PhysicsObjectBasic GetPhysicsObject();
    MovementAttributes GetMovementAttributes();
}