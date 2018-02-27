using Assets.Abilities;
using Assets.Attributes;
using Assets.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Hero : PhysicsObjectBasic, ICharacter
{
    public bool canBuy { get; set; }
    DamageManager dmgManager;
    IExperienceManager experienceManager = new ExperienceManager();
    SkillAttributes skillAttributes = new SkillAttributes();
    IMovementManager movementManager = new MovementManager();
    AnimatorManagerHero animatorManager = new AnimatorManagerHero();
    IVitalityManager vitalityManager = new VitalityManager();
    IHeroAttackManager heroAttackManager = new HeroAttackManager();
    public IInventoryManager inventoryManager = new InventoryManager();
    public IAttack basicAttack;
    public IAttack specialAttack;
    public VitalityAttributes vitalityAttributes = new VitalityAttributes();
    public ExperienceAttribute experienceAttribute = new ExperienceAttribute();
    public TeamAttributes teamAttributes = new TeamAttributes();
    private SpriteRenderer spriteRenderer;
    private Animator animator;
// HEAD
    public InventoryAttributes inventoryAttributes = new InventoryAttributes();
//
	public GameObject particalSystem;
// 5c55ec2b2f2b92f4f36db769a2c93fcf41bd3823

    // Use this for initialization
    void Awake()
    {


        basicAttack = heroAttackManager.GetBasicAttack_SwordHit(teamAttributes.OpossiteTeamLayer);
        specialAttack = heroAttackManager.GetSpecialAttack_LightningStrike(teamAttributes.OpossiteTeamLayer);
        spriteRenderer = GetComponent<SpriteRenderer>();
        experienceManager = new ExperienceManager();
        dmgManager = new DamageManager();
        movementManager = new MovementManager();
        animatorManager = new AnimatorManagerHero();
        animator = GetComponent<Animator>();

        vitalityAttributes.canvas = GameObject.Find("CanvasWorld");
        vitalityAttributes.HealthSlider = Instantiate(vitalityAttributes.SliderToLoad, vitalityAttributes.canvas.gameObject.transform);
        Physics2D.IgnoreLayerCollision(14, 14);
        ShellRadius = .3f;

    }
    float second = 1f;   
    protected override void ComputeVelocity()
    {
        second -= Time.deltaTime;
        if(second <= 0)
        {
            inventoryAttributes.goldAmount++;
            second = 1f;
        }

        var move=movementManager.GetHorizontalMovementVector();
        velocity = movementManager.GetJumpManagementVector(this);
        animatorManager.ExecuteFlipSprite(move.x,this);
        animatorManager.UpdateVelocityParametrer(this);
        basicAttack.SetTargets(dmgManager.GetTargetsInRange(this));
        vitalityAttributes.UpdateHealtheSlider(gameObject);
        movementManager.UpdateTargetVelocity(move, this);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<IDamagable> basicAttackTargets = basicAttack.GetTargets();
            if (basicAttackTargets[0] != null)
            {

                for (int i = 0; i < basicAttackTargets.Count; i++)
                {
                    if (basicAttackTargets[i] != null)
                    {
// HEAD

//
                        
;
                        Debug.Log(basicAttackTargets[i].gameObject().name);
// 5c55ec2b2f2b92f4f36db769a2c93fcf41bd3823
                        IDamagable target = basicAttackTargets[i];
                        Attack(target, gameObject.GetComponent<Rigidbody2D>(), basicAttack);
                    }

                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            int expToAdd = UnityEngine.Random.Range(20, 100);
            experienceManager.AddExperience(experienceAttribute, experienceAttribute.experience + expToAdd);
            if (experienceAttribute.canUpgrade)
                PlayerHUD.playerHUD.SetActive(true);
            inventoryAttributes.goldAmount += 200;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {

            ShopMenuUI.shopMenuUI.SetActive(!(ShopMenuUI.shopMenuUI.activeSelf));


        }
    }


  private void Attack(IDamagable trgt, Rigidbody2D primaryCollider, IAttack attack)
    {
        GameObject ParticleSpark = Instantiate(particalSystem);
        ParticleSpark.transform.position = new Vector3(trgt.gameObject().transform.position.x-0.5f, trgt.gameObject().transform.position.y, trgt.gameObject().transform.position.z);
        StartCoroutine(DestroySpark(ParticleSpark));
        dmgManager.DistributeDamageWithInvincible(trgt.gameObject().GetComponent<ICharacter>(), attack);
        StartCoroutine(Attacking());
        StartCoroutine(GettingAttacked(trgt.gameObject().GetComponent<SpriteRenderer>()));
        vitalityManager.DestroyIfHPIsZero(this);
    //    animatorManager.ExecuteAttackAnimation(this);
    }
    IEnumerator DestroySpark(GameObject Spark)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(Spark);
    }
    IEnumerator GettingAttacked(SpriteRenderer spriteRend)
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRend.color = Color.white;
    }
    IEnumerator Attacking()
    {
        this.GetComponent<ICharacter>().GetAnimator().Play("Attack");
        this.GetComponent<ICharacter>().GetAnimator().SetBool("basicAttack", true);
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<ICharacter>().GetAnimator().SetBool("basicAttack", false);
    }
    /*
    public void BigAbility()
    {
        var basicAttackDamagerAttributes = basicAttack.GetDamageAttributes();
        List<IDamagable> basicAttackTargets = basicAttack.GetTargets();
        for (int i = 0; i < basicAttackTargets.Count; i++)
        {
            IDamagable target = basicAttackTargets[i];
            //basicAttackDamagerAttributes.AttackDamage * 3, 1 / 5f
            //make a new attack based on IAttack with the damage you want and use it here..something of that nature
            Attack(target, gameObject.GetComponent<Rigidbody2D>(), basicAttack);
        }
    }*/

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

    public SkillAttributes GetSkillAttributes()
    {
        return skillAttributes;
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
    public ExperienceAttribute GetExperienceAttributes()
    {
        print(experienceAttribute.experience + " " + experienceAttribute.level);
        return this.experienceAttribute;
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
    GameObject IDamagable.gameObject()
    {
        return this.gameObject;
    }
    #endregion
}

