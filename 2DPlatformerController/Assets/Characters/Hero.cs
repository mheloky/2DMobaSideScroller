using Assets.Abilities;
using Assets.Attributes;
using Assets.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Hero : PhysicsObjectBasic, IDamagable
{
    DamageManager dmgManager;
    IMovementManager movementManger = new MovementManager();
    AnimatorManager animatorManager = new AnimatorManager();
    public IAttack battacks;
    public VitalityAttributes vitalityAttributes = new VitalityAttributes();
    public DamagableAttributes damagableAttributes = new DamagableAttributes();
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Use this for initialization
    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        dmgManager = new DamageManager();
        movementManger = new MovementManager();
        animatorManager = new AnimatorManager();
        animator = GetComponent<Animator>();

        vitalityAttributes.canvas = GameObject.Find("CanvasWorld");
        vitalityAttributes.HealthSlider = Instantiate(vitalityAttributes.SliderToLoad, vitalityAttributes.canvas.gameObject.transform);
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
        
        vitalityAttributes.UpdateHealtheSlider(gameObject);
        TargetVelocity = move * movementAttributes.MaxSpeed;
        damagableAttributes.targets = damagableAttributes.Range(gameObject);
    }

    public void BasicAttack()
    {
        if (damagableAttributes.targets[0] != null)
        {
            foreach (GameObject vr in damagableAttributes.targets)
            {
                Attack(vr.GetComponent<IDamagable>(), gameObject.GetComponent<Rigidbody2D>(), damagableAttributes.AttackDamage,1f);
            }
        }
    }
    public void BigAbility()
    {
        if (damagableAttributes.targets[0] != null)
        {
            foreach (GameObject vr in damagableAttributes.targets)
            {
                Attack(vr.GetComponent<IDamagable>(), gameObject.GetComponent<Rigidbody2D>(), damagableAttributes.AttackDamage*3,1/5f);
            }
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


    private void Attack(IDamagable trgt, Rigidbody2D primaryCollider,int dmg,float cd)
    {
        dmgManager.DistributeDamageWithInvincible(trgt.GetVitalityAttributes(), damagableAttributes, dmg,cd);
        if (trgt.GetVitalityAttributes().HP <= 0)
        {
            //trgt.GetGameObject().GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(trgt.GetHealthSlider().gameObject);
            Destroy(trgt.GetGameObject());
        }
        //trgt.GetVitalityAttributes(), damagableAttributes( this.damagableAttributes.AttackDamage);
        animator.SetBool("basicAttack", true);
        //  secondaryCollider.rigidbody.gameObject.GetComponent<IDamagable>().TakeDamage(this.damagableAttributes.AttackDamage);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Slider GetHealthSlider()
    {
        return vitalityAttributes.HealthSlider;
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}

