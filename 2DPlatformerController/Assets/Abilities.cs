﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Hero))]
public class Abilities : MonoBehaviour {
    private bool IsPlayerShown = true;
    private Hero hero;
    public GameObject LaserImage;
    public GameObject ExplosionImage;
    private GameObject Target;
    bool LaserCd=false;
    bool LaserBeingUsed;
    private GameObject laser;
    bool IsPlayerCasting;
    bool ShieldHasCd;
    public Sprite SpecialAttackSprite;
    public int[] ManaCost;
    // Use this for initialization
    void Start () {
        hero = gameObject.GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Alpha2) && !LaserCd && !IsPlayerCasting && IsPlayerShown && !ShieldHasCd&&hero.vitalityAttributes.MP-ManaCost[1]>=0)
        {
                StartCoroutine(MakeSpriteInvis(gameObject.GetComponent<SpriteRenderer>()));
                hero.vitalityAttributes.HealthSlider.gameObject.SetActive(false);
            hero.vitalityAttributes.ManaSlider.gameObject.SetActive(false);
            hero.vitalityAttributes.MP -= ManaCost[1];
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) &&!LaserCd && !IsPlayerCasting && IsPlayerShown && !ShieldHasCd&&hero.vitalityAttributes.MP - ManaCost[2] >= 0)
        {
            Target = hero.basicAttack.GetTargets()[0].gameObject();
            StartCoroutine(WaitCD( 5f));
            LaserBeingUsed = true;
            laser = Instantiate(LaserImage);
            laser.transform.position = Target.transform.position;
            StartCoroutine(DeployLaser());
            hero.vitalityAttributes.MP -=ManaCost[2];
        }
        if(Input.GetKeyUp(KeyCode.Alpha4) && !LaserCd && !IsPlayerCasting && IsPlayerShown && !ShieldHasCd && hero.vitalityAttributes.MP - ManaCost[3] >= 0)
        {
            ShieldHasCd = true;
            hero.revives = 2;
            hero.Shields[0].SetActive(true);
            hero.Shields[1].SetActive(true);
            StartCoroutine(Shields());
            hero.vitalityAttributes.MP -= ManaCost[3];
        }
            if (Input.GetKeyUp(KeyCode.Alpha1) && !LaserCd && !IsPlayerCasting && IsPlayerShown&&!ShieldHasCd && hero.vitalityAttributes.MP - ManaCost[0] >= 0)
        {
            hero.vitalityAttributes.MP -= ManaCost[0];
            StartCoroutine(SpecialAttack());
        }
        if (LaserBeingUsed)
        {
            laser.transform.position = Vector3.Lerp(laser.transform.position, Target.transform.position, Time.deltaTime * 1f);
        }
    }
    IEnumerator Shields()
    {
        yield return new WaitForSeconds(3f);
        hero.revives = 0;
        hero.Shields[0].SetActive(false);
        hero.Shields[1].SetActive(false);
        ShieldHasCd = false;
    }
    IEnumerator SpecialAttack()
    {
        hero.GetComponent<ICharacter>().GetAnimator().enabled = false;
        hero.cannotWalk = true;
        hero.GetComponent<SpriteRenderer>().sprite = SpecialAttackSprite;

        yield return new WaitForSeconds(1f);
        hero.cannotWalk = false;
        hero.GetComponent<ICharacter>().GetAnimator().enabled = true;
        hero.GetComponent<ICharacter>().GetAnimator().Play("Attack");
        GameObject ParticleSpark = Instantiate(hero.particalSystem);
        IDamagable trgt = hero.basicAttack.GetTargets()[0];
        ParticleSpark.transform.position = new Vector3(trgt.gameObject().transform.position.x, trgt.gameObject().transform.position.y, trgt.gameObject().transform.position.z + 5);
        attack();
        yield return new WaitForSeconds(0.2f);
        Destroy(ParticleSpark);

    }
    void attack()
    {
        IDamagable trgt = hero.basicAttack.GetTargets()[0];
        hero.dmgManager.DistributeDamageWithInvincible(trgt.gameObject().GetComponent<ICharacter>(), hero.specialAttack,gameObject.GetComponent<ICharacter>());
    }
    IEnumerator DeployLaser()
    {
        yield return new WaitForSeconds(3f);
        LaserBeingUsed = false;
        GameObject Explosion = Instantiate(ExplosionImage);
        Explosion.transform.position = laser.transform.position;
        if (Vector3.Distance(Target.transform.position, laser.transform.position) < 2)
        {
            Target.GetComponent<IDamagable>().GetVitalityAttributes().HP -= 50;
        }
            Destroy(laser);
        yield return new WaitForSeconds(0.5f);
        Destroy(Explosion);
    }
    IEnumerator WaitCD(float time)
    {
        LaserCd = true;
        yield return new WaitForSeconds(time);
        LaserCd = false;
    }
    IEnumerator MakeSpriteInvis(SpriteRenderer sprite)
    {
        IsPlayerShown = false;
        yield return new WaitForSeconds(0.05f);
        if (sprite.color.a > 0.1f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - Time.deltaTime * 5f);
            StartCoroutine(MakeSpriteInvis(sprite));
        }
        else
        {
            StartCoroutine(WaitToMakeSpriteVisible(sprite));
        }
    }
    IEnumerator WaitToMakeSpriteVisible(SpriteRenderer sprite)
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(MakeSpriteVis(sprite));
    }
    IEnumerator MakeSpriteVis(SpriteRenderer sprite)
    {
        yield return new WaitForSeconds(0.05f);
        if (sprite.color.a < 1f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + Time.deltaTime * 5f);
            StartCoroutine(MakeSpriteVis(sprite));
        }
        else
        {
            hero.vitalityAttributes.HealthSlider.gameObject.SetActive(true);
            hero.vitalityAttributes.ManaSlider.gameObject.SetActive(true);
            IsPlayerShown = true;
        }
    }
}