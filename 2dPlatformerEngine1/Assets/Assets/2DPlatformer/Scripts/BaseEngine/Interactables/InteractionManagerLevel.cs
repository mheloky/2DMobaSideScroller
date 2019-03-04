using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Interactables
{
    public class InteractionManagerLevel : AInteractionManager
    {
        public AConstitution TheConstitution { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PhysicsObject ThePhysicsObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ReceiveInteraction(ADamage damage)
        {
            throw new NotImplementedException();
        }

        public void SendInteraction(ADamage damage)
        {
            throw new NotImplementedException();
        }
    }
}
