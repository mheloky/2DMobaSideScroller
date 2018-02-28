using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour {

	public GameObject cannon;

	void OnTriggerEnter2D(){
		cannon.SetActive (true);
	}

	void OnTriggerExit2D(){
		cannon.SetActive (false);
	}
}
