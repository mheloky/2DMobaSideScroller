using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._2DPlatformer.Scripts.BaseEngine.GameStructure
{
    public interface AInteractable
    {
        void Interact(ADamage damage);
    }
}
