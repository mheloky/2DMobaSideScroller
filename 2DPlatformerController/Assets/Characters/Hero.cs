using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : PhysicsObjectBasic, IDamagable
{
    DamageManager damageManager;
    MovementManager movementManger = new MovementManager();
    AnimatorManager animatorManager = new AnimatorManager();
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
        damageManager.DistributeDamageWithInvincible(damagableAttributes, damage);
    }

    public DamagableAttributes GetDamagableAttributes()
    {
        return damagableAttributes;
    }
}
