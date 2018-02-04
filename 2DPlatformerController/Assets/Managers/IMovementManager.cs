using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Managers
{
    public interface IMovementManager
    {
        Vector2 ExecuteJumpManagement(PhysicsObjectBasic physicsObjectBasic, string jumpButtonKeyName = "Jump");

        Vector2 ExecuteHorizontalMovement();

    }
}
