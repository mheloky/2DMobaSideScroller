using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TCPIPGame;
using TCPIPGame.Server.DomainObjects;
using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using TCPIPGame.Messages;
using Assets._2DPlatformer.Scripts.BaseEngine.Interactables;

public class Player : MonoBehaviour,APhysicalPlayer,AInteractable
{
    #region Helper Methods
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public bool GetActive(bool active)
    {
        return gameObject.activeSelf;
    }

    public AInteractionManager InteractionManager;
    public AInteractionManager TheInteractionManager
    {
        get
        {
            return InteractionManager;
        }
        set
        {
            InteractionManager = value;
        }
    }
    #endregion
}
