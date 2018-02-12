using Assets.Abilities;
using Assets.Attributes;
using Assets.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCreep : PhysicsObjectBasic, ICharacter
{
        #region Properties
        public DamagerAttributes damagableAttributes = new DamagerAttributes();
        public VitalityAttributes vitalityAttributes = new VitalityAttributes();
        public TeamAttributes teamAttributes = new TeamAttributes();
        public TeamManager teamManager = new TeamManager();
        DamageManager dmgManager = new DamageManager();
        private SpriteRenderer spriteRenderer;
        private Animator animator;
        IAnimatorManager animatorManager = new AnimatorManagerCreep();
        IMovementManager movementManager = new MovementManager();
        public IAttack basicAttack;
        public IVitalityManager vitalityManager = new VitalityManager();
        #endregion

        // Use this for initialization
        private void Start()
        {
            basicAttack = new BasicAttack();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            vitalityAttributes.canvas =GameObject.Find("CanvasWorld");
            vitalityAttributes.HealthSlider = Instantiate(vitalityAttributes.SliderToLoad, vitalityAttributes.canvas.gameObject.transform);
            Physics2D.IgnoreLayerCollision(14, 14);
            Physics2D.IgnoreLayerCollision(15, 15);
        }

        protected override void ComputeVelocity()
        {
            var move = teamManager.GetDirectionVector(teamAttributes);
            animatorManager.ExecuteFlipSprite(move.x, this);
            vitalityAttributes.UpdateHealtheSlider(gameObject);
            basicAttack.SetTargets(dmgManager.GetTargetsInRange(this));

            var basicAttackDamagerAttributes = basicAttack.GetDamageAttributes();
            var targets = basicAttack.GetTargets();
            for (int i = 0; targets != null && i < targets.Count; i++)
            {
                var target = targets[i];
                //basicAttackDamagerAttributes.AttackDamage * 3, 1 / 5f
                //make a new attack based on IAttack with the damage you want and use it here..something of that nature
                Attack(target, gameObject.GetComponent<Rigidbody2D>(), basicAttack);
            }
            movementManager.UpdateTargetVelocity(move, this);
        }

        public DamagerAttributes GetDamagerAttributes()
        {
            return damagableAttributes;
        }

        public VitalityAttributes GetVitalityAttributes()
        {
            return vitalityAttributes;
        }

        private void Attack(IDamagable trgt, Rigidbody2D primaryCollider, IAttack attack)
        {
            dmgManager.DistributeDamageWithInvincible(this, attack);
            animatorManager.ExecuteAttackAnimation(this);
        }

        public void TakeDamage(int damage)
        {
            var shouldBeDestroyed = dmgManager.DistributeDamageWithInvincible(this,basicAttack);
            vitalityManager.DestroyIfHPIsZero(this, shouldBeDestroyed);
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

        public TeamAttributes GetTeamAttributes()
        {
            return teamAttributes;
        }

        public SpriteRenderer GetSpriteRenderer()
        {
        return this.spriteRenderer;
        }

        public Animator GetAnimator()
        {
            return this.animator;
        }

        public PhysicsObjectBasic GetPhysicsObject()
        {
            return this;
        }

        public MovementAttributes GetMovementAttributes()
        {
            return this.movementAttributes;
        }
    #endregion
}