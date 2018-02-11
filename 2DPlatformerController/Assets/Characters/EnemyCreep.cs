using Assets.Abilities;
using Assets.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCreep : PhysicsObjectBasic, IDamagable
    {
        #region Properties
        public DamagableAttributes damagableAttributes = new DamagableAttributes();
        public VitalityAttributes vitalityAttributes = new VitalityAttributes();
        DamageManager dmgManager = new DamageManager();
        private SpriteRenderer spriteRenderer;
        private Animator animator;
        public IAttack battacks;
        #endregion

        // Use this for initialization
        private void Start()
        {
        //    TheCollisionDetector.CollisionDetectedEvent += TheCollisionDetector_CollisionDetectedEvent;
            battacks = new BasicAttack();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            vitalityAttributes.canvas =GameObject.Find("CanvasWorld");
            vitalityAttributes.HealthSlider = Instantiate(vitalityAttributes.SliderToLoad, vitalityAttributes.canvas.gameObject.transform);
            Physics2D.IgnoreLayerCollision(14, 14);
            Physics2D.IgnoreLayerCollision(15, 15);
        }

        protected override void ComputeVelocity()
        {
            var move = Vector2.right;

            if (vitalityAttributes.Team == TAGS.Team2)
                move = Vector2.left;


            bool flipSprite = (spriteRenderer.flipX ? (vitalityAttributes.Team == TAGS.Team2) : (vitalityAttributes.Team == TAGS.Team1));
            if (!flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        vitalityAttributes.UpdateHealtheSlider(gameObject);
        damagableAttributes.targets= damagableAttributes.Range(gameObject);
        if (damagableAttributes.targets[0] != null)
        {
            foreach (GameObject vr in damagableAttributes.targets)
            {
                Attack(vr.GetComponent<IDamagable>(), gameObject.GetComponent<Rigidbody2D>(),1f);
            }
        }
        //animator.SetBool("grounded", TheCollisionDetector.IsGrounded);
        // animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        //print(":::::::" + Mathf.Abs(velocity.x) / maxSpeed);
        TargetVelocity = move * movementAttributes.MaxSpeed;
        }



        public DamagableAttributes GetDamagableAttributes()
        {
            return damagableAttributes;
        }

        public VitalityAttributes GetVitalityAttributes()
        {
            return vitalityAttributes;
        }

        private void Attack(IDamagable trgt, Rigidbody2D primaryCollider,float cd)
        {
            dmgManager.DistributeDamageWithInvincible(trgt.GetVitalityAttributes(), damagableAttributes, this.damagableAttributes.AttackDamage,cd);
        
            //trgt.GetVitalityAttributes(), damagableAttributes( this.damagableAttributes.AttackDamage);
            animator.SetBool("basicAttack", true);
            //  secondaryCollider.rigidbody.gameObject.GetComponent<IDamagable>().TakeDamage(this.damagableAttributes.AttackDamage);
        }

        public void TakeDamage(int damage)
        {
            var shouldBeDestroyed = dmgManager.DistributeDamageWithInvincible(vitalityAttributes, damagableAttributes, damage,1);

            if (shouldBeDestroyed)
            {
                Destroy(this.gameObject);
            }
        }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Slider GetHealthSlider()
    {
        return vitalityAttributes.HealthSlider;
    }
}