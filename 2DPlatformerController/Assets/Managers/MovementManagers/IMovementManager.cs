using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Managers
{
    public interface IMovementManager
    {
        Vector2 GetJumpManagementVector(PhysicsObjectBasic physicsObjectBasic, string jumpButtonKeyName = "Jump");
        Vector2 GetHorizontalMovementVector();
        void UpdateTargetVelocity(Vector2 move, ICharacter character);
    }
}
