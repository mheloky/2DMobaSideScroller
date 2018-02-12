﻿using Assets.Abilities;
using Assets.Attributes;
using Assets.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Hero : PhysicsObjectBasic, ICharacter
{
    DamageManager dmgManager;
    IMovementManager movementManger = new MovementManager();
    AnimatorManagerHero animatorManager = new AnimatorManagerHero();
    IVitalityManager vitalityManager = new VitalityManager();
    public IAttack basicAttack;
    public VitalityAttributes vitalityAttributes = new VitalityAttributes();
    public TeamAttributes teamAttributes = new TeamAttributes();
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        dmgManager = new DamageManager();
        movementManger = new MovementManager();
        animatorManager = new AnimatorManagerHero();
        animator = GetComponent<Animator>();

        vitalityAttributes.canvas = GameObject.Find("CanvasWorld");
        vitalityAttributes.HealthSlider = Instantiate(vitalityAttributes.SliderToLoad, vitalityAttributes.canvas.gameObject.transform);
        Physics2D.IgnoreLayerCollision(14, 14);
        ShellRadius = .3f;
    }
       
    protected override void ComputeVelocity()
    {
        var move=movementManger.GetHorizontalMovementVector();
        velocity = movementManger.GetJumpManagementVector(this);
        animatorManager.ExecuteFlipSprite(move.x,this);
        animatorManager.UpdateVelocityParametrer(this);
        
        vitalityAttributes.UpdateHealtheSlider(gameObject);
        movementManger.UpdateTargetVelocity(move, this);
        basicAttack.SetTargets(dmgManager.GetTargetsInRange(this));
    }

    public void BasicAttack()
    {
        var basicAttackTargets = basicAttack.GetTargets();
        for (int i=0;i< basicAttackTargets.Count;i++)
        {
            var target = basicAttackTargets[i];
            Attack(target, gameObject.GetComponent<Rigidbody2D>(),basicAttack);
        }
    }

    private void Attack(IDamagable trgt, Rigidbody2D primaryCollider, IAttack attack)
    {
        dmgManager.DistributeDamageWithInvincible(this, attack);
        vitalityManager.DestroyIfHPIsZero(this);
        animatorManager.ExecuteAttackAnimation(this);
    }

    public void BigAbility()
    {
        var basicAttackDamagerAttributes = basicAttack.GetDamageAttributes();
        var targets = basicAttack.GetTargets();
        for(int i=0; targets!=null && i<targets.Count;i++)
        {
            var target = targets[i];
            //basicAttackDamagerAttributes.AttackDamage * 3, 1 / 5f
            //make a new attack based on IAttack with the damage you want and use it here..something of that nature
            Attack(target, gameObject.GetComponent<Rigidbody2D>(), basicAttack);
        }
    }

    #region Required Character Methods
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

    public TeamAttributes GetTeamAttributes()
    {
        return teamAttributes;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    public PhysicsObjectBasic GetPhysicsObject()
    {
        return this;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public MovementAttributes GetMovementAttributes()
    {
        return movementAttributes;
    }

    public DamagerAttributes GetDamagerAttributes()
    {
        return basicAttack.GetDamageAttributes();
    }

    public VitalityAttributes GetVitalityAttributes()
    {
        return vitalityAttributes;
    }
    #endregion
}

