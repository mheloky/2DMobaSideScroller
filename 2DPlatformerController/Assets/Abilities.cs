using System.Collections;
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
    // Use this for initialization
    void Start () {
        hero = gameObject.GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Alpha2)&&IsPlayerShown)
        {
                StartCoroutine(MakeSpriteInvis(gameObject.GetComponent<SpriteRenderer>()));
                hero.vitalityAttributes.HealthSlider.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) &&!LaserCd)
        {
            Target = hero.basicAttack.GetTargets()[0].gameObject();
            StartCoroutine(WaitCD( 5f));
            LaserBeingUsed = true;
            laser = Instantiate(LaserImage);
            laser.transform.position = Target.transform.position;
            StartCoroutine(DeployLaser());
        }
        if (LaserBeingUsed)
        {
            laser.transform.position = Vector3.Lerp(laser.transform.position, Target.transform.position, Time.deltaTime * 1f);
        }
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
            IsPlayerShown = true;
        }
    }
}
