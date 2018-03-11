using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTower : MonoBehaviour {
    public Tower tower;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == tower.teamAttributes.OpossiteTeamLayer&& tower.target==null)
        {
            tower.target = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject== tower.target)
        {
            tower.target = null;
        }
    }
}
