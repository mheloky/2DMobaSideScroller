using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupMenuScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();

    public bool isVisible = false;

    // Use this for initialization
    void Start () {
        this.gameObject.SetActive(isVisible);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
