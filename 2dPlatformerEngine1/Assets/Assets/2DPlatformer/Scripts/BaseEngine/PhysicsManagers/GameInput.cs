using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers
{
    public class GameInput: AGameInput
    {
        public int ClientID
        {
            get;
            set;
        }
        public float? HorizontalAxis
        {
            get;
            set;
        }
        public bool? Jump
        {
            get;
            set;

        }
        public float? PositionX 
        {
            get;
            set;

        }
        public float? PositionY
        {
            get;
            set;
        }
    }
}
