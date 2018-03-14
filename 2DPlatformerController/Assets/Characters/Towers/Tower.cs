using Assets.Abilities;
using Assets.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : PhysicsObjectBasic, ICharacter
{

    #region properties
    IExperienceManager experienceManager = new ExperienceManager();
    SkillAttributes skillAttributes = new SkillAttributes();
    public IAttack basicAttack;
    public DamageManager dmgManager=new DamageManager();
    public VitalityAttributes vitalityAttributes = new VitalityAttributes();
    public ExperienceAttribute experienceAttribute = new ExperienceAttribute();
    public TeamAttributes teamAttributes = new TeamAttributes();
    public TowerAttackManager towerAttackManager = new TowerAttackManager();
    private GameObject target;
    bool hasCD;
    public LineRenderer line;
    public GameObject Spark;
    //private IAttac
    #endregion
    // Use this for initialization
    void Start()
    {
        basicAttack = towerAttackManager.basic(teamAttributes.OpossiteTeamLayer);
        
    }
    void Awake()
    {
        vitalityAttributes.canvas = GameObject.Find("CanvasWorld");
        vitalityAttributes.HealthSlider = Instantiate(vitalityAttributes.SliderToLoad, vitalityAttributes.canvas.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        vitalityAttributes.UpdateHealtheSlider(gameObject);
        if (target != null)
       Attack();
        float boxSize=10;
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position,new Vector2(boxSize, boxSize),0);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x - boxSize/2, transform.position.y, transform.position.z));
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.layer == teamAttributes.OpossiteTeamLayer)
            {
                target = hitColliders[i].gameObject;
                Debug.Log("EnemyEntered");
                break;
            }
            Debug.Log("EnemyNotEntered");
            target = null;
            i++;
        }
    }
    void Attack()
    {
        if (!hasCD)
        {
            hasCD = true;
            if (!(target.GetComponent<IDamagable>().GetVitalityAttributes().HP - basicAttack.GetDamageAttributes().AttackDamage <= 0))
            {
                target.GetComponent<IDamagable>().GetVitalityAttributes().HP -= basicAttack.GetDamageAttributes().AttackDamage;
            }
            else if (target.GetComponent<Hero>() != null&&target.GetComponent<Hero>().revives>0)
            {
                target.GetComponent<IDamagable>().GetVitalityAttributes().HP = 1;
            }
            else
            {
                target.GetComponent<IDamagable>().GetVitalityAttributes().HP -= basicAttack.GetDamageAttributes().AttackDamage;
            }
            line.SetPosition(0, target.transform.position);
            line.SetPosition(1, new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z+10));
            GameObject ParticleSpark = Instantiate(Spark);
            ParticleSpark.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + 5);
            ParticleSpark.GetComponent<Spark>().target = target.transform;
            StartCoroutine(CoolDown(ParticleSpark));
        }
    }
    IEnumerator CoolDown(GameObject Spark)
    {
        yield return new WaitForSeconds(0.5f);
        line.SetPosition(0, new Vector2(1111, 1111));
        line.SetPosition(1, new Vector2(1111, 1111));
        yield return new WaitForSeconds(1f);
        hasCD = false;
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

    public TeamAttributes GetTeamAttributes()
    {
        return teamAttributes;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return GetComponent<SpriteRenderer>();
    }

    public PhysicsObjectBasic GetPhysicsObject()
    {
        return this;
    }

    public SkillAttributes GetSkillAttributes()
    {
        throw new NotImplementedException();
    }

    public ExperienceAttribute GetExperienceAttributes()
    {
        print(experienceAttribute.experience + " " + experienceAttribute.level);
        return this.experienceAttribute;
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
        return gameObject;
    }

    public Animator GetAnimator()
    {
        return null;
    }

    public MovementAttributes GetMovementAttributes()
    {
        return null;
    }
}