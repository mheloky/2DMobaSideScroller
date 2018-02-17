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
        public VitalityAttributes vitalityAttributes = new VitalityAttributes();
        [Header("Put 9 if it's team 2 and put 8 if it's team 1")]
        public TeamAttributes teamAttributes = new TeamAttributes();
        public TeamManager teamManager = new TeamManager();
        DamageManager dmgManager = new DamageManager();
        private SpriteRenderer spriteRenderer;
        private Animator animator;
        IAnimatorManager animatorManager = new AnimatorManagerCreep();
        IMovementManager movementManager = new MovementManager();
        CreepAttackManager attackManager = new CreepAttackManager();
        public IAttack basicAttack;
        public IVitalityManager vitalityManager = new VitalityManager();
        #endregion

        // Use this for initialization
        private void Start()
        {
            basicAttack = attackManager.GetBasicAttack_SwordHit(teamAttributes.OpossiteTeamLayer);
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
            List<IDamagable> targets = basicAttack.GetTargets();
            for (int i = 0;i < targets.Count; i++)
            {

                IDamagable target = targets[i];
                //basicAttackDamagerAttributes.AttackDamage * 3, 1 / 5f
                //make a new attack based on IAttack with the damage you want and use it here..something of that nature
                Attack(target, gameObject.GetComponent<Rigidbody2D>(), basicAttack);
            }
            movementManager.UpdateTargetVelocity(move, this);
        }

    public DamagerAttributes GetDamagerAttributes()
        {
        return basicAttack.GetDamageAttributes();
        }

        public VitalityAttributes GetVitalityAttributes()
        {
            return vitalityAttributes;
        }

        private void Attack(IDamagable trgt, Rigidbody2D primaryCollider, IAttack attack)
        {
            dmgManager.DistributeDamageWithInvincible(trgt.gameObject().GetComponent<ICharacter>(), attack);
        StartCoroutine(GettingAttacked(trgt.gameObject().GetComponent<SpriteRenderer>()));
        animatorManager.ExecuteAttackAnimation(this);
        }

        public void TakeDamage(int damage)
        {
            var shouldBeDestroyed = dmgManager.DistributeDamageWithInvincible(this,basicAttack);
            vitalityManager.DestroyIfHPIsZero(this, shouldBeDestroyed);
        }
    IEnumerator GettingAttacked(SpriteRenderer spriteRend)
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRend.color = Color.white;
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

    GameObject IDamagable.gameObject()
    {
        return this.gameObject;
    }
    #endregion
}