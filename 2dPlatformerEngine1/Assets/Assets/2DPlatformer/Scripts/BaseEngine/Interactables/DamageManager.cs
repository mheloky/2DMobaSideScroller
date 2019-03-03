using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Interactables
{
    public class DamageManager : MonoBehaviour, AInteractionManager
    {
        #region Properties
        public AConstitution TheConstitution
        {
            get;
            set;
        }
        public PhysicsObject ThePhysicsObject
        {
            get;
            set;
        }
        #endregion

        public void Start()
        {
            TheConstitution = GetComponent<AConstitution>();
        }

        public void SendInteraction(ADamage damage)
        {
            lock (ThePhysicsObject.CollidedItems)
            {
                for (int i = 0; i < ThePhysicsObject.CollidedItems.Length; i++)
                {
                    (ThePhysicsObject.CollidedItems[i].rigidbody.GetComponent<AInteractionManager>()).ReceiveInteraction(damage);
                }
            }
        }

        public void ReceiveInteraction(ADamage damage)
        {
            TheConstitution.TheHP = TheConstitution.TheHP - damage.PhysicalDamage;
        }
    }
}
