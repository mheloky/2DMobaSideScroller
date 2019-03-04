using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Interactables
{
    public interface AInteractionManager
    {
        void SendInteraction(ADamage damage);
        void ReceiveInteraction(ADamage damage);
    }
}
