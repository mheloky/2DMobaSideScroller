using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public bool isVisible = false;


    // Use this for initialization
    void Start () {
        theUIPresenter.Initialize(this.gameObject, isVisible);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
