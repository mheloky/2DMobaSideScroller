using Assets.Abilities;
using Assets.Attributes;
using Assets.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingProjectile : BaseProjectile {

	#region Properties
	public VitalityAttributes vitalityAttributes = new VitalityAttributes();
	public ExperienceAttribute experienceAttribute = new ExperienceAttribute();
	[Header("Put 9 if it's team 2 and put 8 if it's team 1")]
	public TeamAttributes teamAttributes = new TeamAttributes();
	public TeamManager teamManager = new TeamManager();
	DamageManager dmgManager = new DamageManager();
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	IExperienceManager experienceManager = new ExperienceManager();
	IAnimatorManager animatorManager = new AnimatorManagerCreep();
	IMovementManager movementManager = new MovementManager();
	CreepAttackManager attackManager = new CreepAttackManager();
	SkillAttributes skillAttributes = new SkillAttributes();
	public IAttack basicAttack;
	public IVitalityManager vitalityManager = new VitalityManager();
	public GameObject particalSystem;
	public AudioSource audio;
	#endregion

	GameObject m_target;
	public GameObject target;

	void Update(){
		if(m_target){
			transform.position = Vector3.MoveTowards (transform.position, m_target.transform.position, speed * Time.deltaTime);
			if(m_target.transform.position.Equals (gameObject.transform.position)){
				
				List<IDamagable> targets = basicAttack.GetTargets();
				IDamagable target = targets[1];
				dmgManager.DistributeDamageWithInvincible(target, 5f, GetComponent<AudioSource>(), particalSystem);
				Destroy (gameObject, 1f);
			}
		}
	}

	public override void FireProjectile (GameObject launcher, GameObject target, int damage){
		if(target){
			m_target = target;
		}
	}

	IEnumerator Hold(){
		yield return new WaitForSeconds (2);
	}

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

	public IExperienceManager GetExperienceManager()
	{
		return experienceManager;
	}

	public ExperienceAttribute GetExperienceAttributes()
	{
		return experienceAttribute;
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

}
