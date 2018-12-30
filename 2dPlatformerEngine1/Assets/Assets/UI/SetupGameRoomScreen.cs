using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGameRoomScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public multiplayerScreen theMultiplayerScreen;
    public bool isVisible = false;

    // Use this for initialization
    void Start () {
        theUIPresenter.Initialize(this.gameObject, isVisible);
        theMultiplayerScreen.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
