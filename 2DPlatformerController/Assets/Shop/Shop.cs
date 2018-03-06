using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    public GameObject shopUI;


	// Use this for initialization
	void Awake () {
        //shopUI = GameObject.Find("MenuHUD");
        //shopUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hero[] heros = GameObject.FindObjectsOfType<Hero>();
        foreach(Hero hero in heros)
        {
            if (collision.gameObject.GetComponent<Hero>() == hero && collision.gameObject.tag == gameObject.tag)
            {
                hero.canBuy = true;
                
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Hero[] heros = GameObject.FindObjectsOfType<Hero>();
        foreach (Hero hero in heros)
        {
            if (collision.gameObject.GetComponent<Hero>() == hero && collision.gameObject.tag == gameObject.tag)
            {
                hero.canBuy = false;

            }
        }
    }

}
