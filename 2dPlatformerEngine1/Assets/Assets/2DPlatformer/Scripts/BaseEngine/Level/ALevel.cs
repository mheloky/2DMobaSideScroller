using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Level
{
    public interface ALevel
    {
        GameObject GetLeftCameraBoundry();
        GameObject GetRightCameraBoundry();
    }
}
