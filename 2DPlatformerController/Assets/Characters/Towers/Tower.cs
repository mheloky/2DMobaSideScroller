using Assets.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : PhysicsObjectBasic {

    #region properties
    public DamagerAttributes damagableAttributes = new DamagerAttributes();
    public VitalityAttributes vitalityAttributes = new VitalityAttributes();
    public TeamAttributes teamAttributes = new TeamAttributes();
    //private IAttac
    #endregion
    // Use this for initialization
    void Start () {
		
	}
    void Awake()
    {
       
    }

        // Update is called once per frame
    void Update () {
       
    }

    public void TakeDamage(int damage)
    {
        DamageManager dmgManager = new DamageManager();
    //    var shouldBeDestroyed=dmgManager.DistributeDamageWithInvincible(vitalityAttributes, damagableAttributes, damage);

       // if (shouldBeDestroyed)
            //Destroy(this);
    }

    public DamagerAttributes GetDamagerAttributes()
    {
        return damagableAttributes;
    }

    public VitalityAttributes GetVitalityAttributes()
    {
        return vitalityAttributes;
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Slider GetHealthSlider()
    {
        throw new NotImplementedException();
    }
}

