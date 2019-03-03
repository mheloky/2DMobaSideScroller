using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Sounds_and_Effects
{
    public interface ASoundManager
    {
        List<AudioClip> GetSounds();
    }
}
