using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using Assets._2DPlatformer.Scripts.BaseEngine.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Level
{
    public class Ground : MonoBehaviour, AInteractable
    {
        public AInteractionManager TheInteractionManager
        {
            get;
            set;
        }
    }
}
