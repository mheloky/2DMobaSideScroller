using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Exit(string zz)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
