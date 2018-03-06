using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Attributes
{
    [System.Serializable]
    public class VitalityAttributes
    {
        
        public bool isHero;
        public float MaxHP;
        public float HP;
        public bool IsInvincible;
        public Slider SliderToLoad;
        public float height;
        [HideInInspector]
        public Slider HealthSlider;
        [HideInInspector]
        public GameObject canvas;
        [HideInInspector]
        public AudioSource audioSource;
        public AudioClip clip;
        public AudioClip StepSound;
        public void UpdateHealtheSlider(GameObject gameObject)
        {
            HealthSlider.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z);
            HealthSlider.value = HP;
            ColorBlock cb = HealthSlider.colors;
            if (HP > (MaxHP * (2f / 3f)))
            {
                cb.normalColor = Color.green;
                HealthSlider.colors = cb;
            }
            else if (HP > (MaxHP * (1f / 3f)))
            {
                cb.normalColor = Color.yellow;
                HealthSlider.colors = cb;
            }
            else if (HP > MaxHP * (1f /6f)) 
            {
                cb.normalColor = Color.red;
                HealthSlider.colors = cb;
            }
            
            else if (HP < MaxHP*(1f/6f))
            {
                cb.normalColor = new Color(0.4f,0,0);
                HealthSlider.colors = cb;
            }
            if (HP <= 0)
            {
                if (isHero)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    HealthSlider.gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(false);
                    HealthSlider.gameObject.SetActive(false);
                }
                //trgt.GetGameObject().GetComponent<SpriteRenderer>().color = Color.red;
                //   Destroy(damagableAttributes.HealthSlider.gameObject);
                //  Destroy(gameObject);
            }
        }

        public void RegenerateHP()
        {

        }
    }
}
