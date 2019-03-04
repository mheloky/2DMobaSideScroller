using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers
{
    public interface ACollisionManager
    {
        ContactFilter2D TheContactFilter
        {
            get;
            set;
        }
        float TheShellRadius
        {
            get;
            set;    
        }

        event Action<RaycastHit2D[]> CollisionDetected;
        RaycastHit2D[] GetRayCastCollisionElements(Vector2 direction, float distance, Rigidbody2D rigidbody2D);
    }
}
