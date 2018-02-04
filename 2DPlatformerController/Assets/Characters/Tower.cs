using Assets.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : PhysicsObjectBasic,IDamagable {

    #region properties
    public DamagableAttributes damagableAttributes = new DamagableAttributes();
    public VitalityAttributes vitalityAttributes = new VitalityAttributes();
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
        var shouldBeDestroyed=dmgManager.DistributeDamageWithInvincible(vitalityAttributes, damagableAttributes, damage);

        if (shouldBeDestroyed)
            Destroy(this);
    }

    public DamagableAttributes GetDamagableAttributes()
    {
        return damagableAttributes;
    }
}

