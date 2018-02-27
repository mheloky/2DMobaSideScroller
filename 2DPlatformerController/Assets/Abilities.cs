using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Hero))]
public class Abilities : MonoBehaviour {
    private bool IsShown = true;
    private Hero hero;
    // Use this for initialization
    void Start () {
        hero = gameObject.GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (IsShown)
            {
                StartCoroutine(MakeSpriteInvis(gameObject.GetComponent<SpriteRenderer>()));
                hero.vitalityAttributes.HealthSlider.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator MakeSpriteInvis(SpriteRenderer sprite)
    {
        IsShown = false;
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
            IsShown = true;
        }
    }
}
