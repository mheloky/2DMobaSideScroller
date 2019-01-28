using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class CollisionManager
    {
        ContactFilter2D contactFilter;
        public const float ShellRadius = 0.01f;
        public event Action<RaycastHit2D[]> CollisionDetected;

        public CollisionManager(int collisionLayer)
        {
            //physicsObjects.GetGameObject().layer)
            contactFilter = new ContactFilter2D();
            contactFilter.useTriggers = false;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(collisionLayer));
            contactFilter.useLayerMask = true;
        }

        public RaycastHit2D[] GetRayCastCollisionElements(Vector2 direction, float distance, Rigidbody2D rigidbody2D)
        {
            RaycastHit2D[] raycastElementsHit = new RaycastHit2D[16];
            int count = rigidbody2D.Cast(direction, contactFilter, raycastElementsHit, distance);
            RaycastHit2D[] rayCastActualElementsHit = new RaycastHit2D[count];
            for (int i = 0; i < rayCastActualElementsHit.Length; i++)
            {
                rayCastActualElementsHit[i] = raycastElementsHit[i];
            }

            if(CollisionDetected!=null)
            {
                CollisionDetected(rayCastActualElementsHit);
            }

            return rayCastActualElementsHit;
        }
    }
}
