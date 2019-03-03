using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using Assets._2DPlatformer.Scripts.BaseEngine.Interactables;
using Assets._2DPlatformer.Scripts.BaseEngine.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlainsLevel : MonoBehaviour,ALevel
{

    #region Properties
    public AInteractionManager TheInteractionManager;
    public GameObject LeftCameraBoundry;
    public GameObject RightCameraBoundry;
    #endregion


    public GameObject GetLeftCameraBoundry()
    {
        return LeftCameraBoundry;
    }

    public GameObject GetRightCameraBoundry()
    {
        return RightCameraBoundry;
    }

    public void Interact(ADamage damage)
    {
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
