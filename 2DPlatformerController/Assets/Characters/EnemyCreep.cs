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
            TheCollisionDetector.CollisionDetectedEvent += TheCollisionDetector_CollisionDetectedEvent;
            battacks = new BasicAttack();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            vitalityAttributes.HP = 100;
            damagableAttributes.canvas = FindObjectOfType<Canvas>();
            damagableAttributes.HealthSlider = Instantiate(damagableAttributes.SliderToLoad,damagableAttributes.canvas.gameObject.transform);
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
        damagableAttributes.HealthSlider.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + damagableAttributes.height, gameObject.transform.position.z);
        damagableAttributes.HealthSlider.value = vitalityAttributes.HP;
        ColorBlock cb = damagableAttributes.HealthSlider.colors;
        if (vitalityAttributes.HP > 70)
        {
            cb.normalColor = Color.green;
            damagableAttributes.HealthSlider.colors = cb;
        }
        else if (vitalityAttributes.HP > 30)
        {
            cb.normalColor = Color.yellow;
            damagableAttributes.HealthSlider.colors = cb;
        }
        else if (vitalityAttributes.HP <30)
        {
            cb.normalColor = Color.red;
            damagableAttributes.HealthSlider.colors = cb;
        }
        else if (vitalityAttributes.HP < 1)
        {
            cb.normalColor = Color.black;
            damagableAttributes.HealthSlider.colors = cb;
        }
        if (vitalityAttributes.HP <= 0)
        {
            //trgt.GetGameObject().GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(damagableAttributes.HealthSlider.gameObject);
            Destroy(gameObject);
        }
        //animator.SetBool("grounded", TheCollisionDetector.IsGrounded);
        // animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        //print(":::::::" + Mathf.Abs(velocity.x) / maxSpeed);
        TargetVelocity = move * movementAttributes.MaxSpeed;
        }

    private void TheCollisionDetector_CollisionDetectedEvent(RaycastHit2D secondaryCollider, Rigidbody2D primaryCollider)
    {
        // Attack(secondaryCollider, primaryCol lider);\   
        // var possibleTarget = secondaryCollider.rigidbody.gameObject.GetComponent<IDamagable>();
        IDamagable possibleTarget=null;
        try
        {
            possibleTarget = secondaryCollider.rigidbody.gameObject.GetComponent<IDamagable>();

        }
        catch(Exception e)
        {
            int a = 100;

        }
            if (possibleTarget == null)
                return;
            //  secondaryCollider.rigidbody.gameObject. GetComponent<IDamagable>() null reference 
            var targets = battacks.GetTargets();
            if (targets.Count < GetDamagableAttributes().Cleave && !targets.Contains(possibleTarget))
            {
                targets.Add(possibleTarget);
            }
            foreach (var item in targets)
            {
                Attack(item, primaryCollider);
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

        private void Attack(IDamagable trgt, Rigidbody2D primaryCollider)
        {
            dmgManager.DistributeDamageWithInvincible(trgt.GetVitalityAttributes(), damagableAttributes, this.damagableAttributes.AttackDamage);
        
            //trgt.GetVitalityAttributes(), damagableAttributes( this.damagableAttributes.AttackDamage);
            animator.SetBool("basicAttack", true);
            //  secondaryCollider.rigidbody.gameObject.GetComponent<IDamagable>().TakeDamage(this.damagableAttributes.AttackDamage);
        }

        public void TakeDamage(int damage)
        {
            var shouldBeDestroyed = dmgManager.DistributeDamageWithInvincible(vitalityAttributes, damagableAttributes, damage);

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
        return damagableAttributes.HealthSlider;
    }
}