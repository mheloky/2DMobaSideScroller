using Assets.Abilities;
using Assets.Attributes;
using Assets.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hero : PhysicsObjectBasic, IDamagable
{
    DamageManager damageManager;
    IMovementManager movementManger = new MovementManager();
    AnimatorManager animatorManager = new AnimatorManager();
    public IAttack basicAttack;
    public VitalityAttributes vitalityAttributes = new VitalityAttributes();
    public DamagableAttributes damagableAttributes = new DamagableAttributes();
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageManager = new DamageManager();
        movementManger = new MovementManager();
        animatorManager = new AnimatorManager();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(14, 14);
        ShellRadius = .3f;
    }
    //is your phone charged?
    //also i was thinking, imo the TakeDamage() should be handled as deal dmg instead of takeDmg for 2 main reasons . will call you in 2 miunutes
    //sure lemme think about what i was wanting to say xD So, if for example you as the creep go close to all the creeps of the enemy team, you would
    //kill all of them because you deal cleave damage. If the attack damage was handled in the creep you wouldn't because you could limit the ammount of cleave
    //by saying how many objects to damage at once. Hope you understand what am trying to say
    //starting up my oither computer with skype - one moment -kk
       
    protected override void ComputeVelocity()
    {
        var move=movementManger.ExecuteHorizontalMovement();
        var newVelocity=movementManger.ExecuteJumpManagement(this);
        velocity = newVelocity;
        animatorManager.ExecuteFlipSprite(move.x,spriteRenderer);
        animatorManager.UpdateVelocityParametrer(animator, this);

        TargetVelocity = move * movementAttributes.MaxSpeed;
    }

    public void TakeDamage(int damage)
    {
     var isitDead = damageManager.DistributeDamageWithInvincible(vitalityAttributes,  damagableAttributes, damage);
        if (isitDead)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public DamagableAttributes GetDamagableAttributes()
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
}

