using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class PhysicsObjectStatus
    {
        public bool isGrounded
        {
            get;
            set;
        }

        public PhysicsObjectStatus()
        {
            isGrounded = false;
        }
    }
}
