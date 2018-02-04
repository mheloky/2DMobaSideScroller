using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : PhysicsObjectBasic,IDamagable {

    #region properties
    public DamagableAttributes gameObjectAttributes=new DamagableAttributes();
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
        var shouldBeDestroyed=dmgManager.DistributeDamageWithInvincible(gameObjectAttributes, damage);

        if (shouldBeDestroyed)
            Destroy(this);
    }

    public DamagableAttributes GetDamagableAttributes()
    {
        return gameObjectAttributes;
    }
}

