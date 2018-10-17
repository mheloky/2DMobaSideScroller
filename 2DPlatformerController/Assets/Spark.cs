using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Awake () {
        StartCoroutine(Suicide());
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position;
        
	}
    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
