using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Sounds_and_Effects
{
    public class SoundManagerPlayer : MonoBehaviour, ASoundManager
    {
        AudioClip AudioClipGrassWalk;

        public List<AudioClip> GetSounds()
        {
            return new AudioClip[] { AudioClipGrassWalk }.ToList();
        }

        public void PlaySoundGrassWalk()
        {
            AudioSource.PlayClipAtPoint(AudioClipGrassWalk, new Vector3());
        }
    }
}
