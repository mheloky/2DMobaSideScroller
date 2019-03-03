using PhysicsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers
{
    public interface AInputManager
    {
        float NetworkHorizontalAxis
        {
            get;
            set;
        }

        bool NetworkJump
        {
            get;
            set;
        }

        APhysicsObject ThePhysicsObject
        {
            get;
            set;
        }
    }
}
