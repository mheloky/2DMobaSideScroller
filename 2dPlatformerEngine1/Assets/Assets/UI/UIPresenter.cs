using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIPresenter
    {
        public void Initialize(GameObject gameObject, bool isVisible)
        {
            SetVisibility(gameObject, isVisible);
        }

        public void Initialize(MonoBehaviour monoBehaviour, bool isVisible)
        {
            SetVisibility(monoBehaviour.gameObject, isVisible);
        }

        public void SetVisibility(GameObject gameObject, bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}
