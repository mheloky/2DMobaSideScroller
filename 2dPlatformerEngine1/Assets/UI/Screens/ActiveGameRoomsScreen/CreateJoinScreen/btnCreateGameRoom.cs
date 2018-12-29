using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnCreateGameRoom : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public GameObject btnGameRoomTemplate;
    public GameObject ActiveGameRoomsScreen;
    public GameObject CreateGameScreen;

    public bool IsVisible = true;

	// Use this for initialization
	void Start () {
        theUIPresenter.Initialize(this.gameObject, IsVisible);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click_CreateRoom(string aa)
    {
        CreateGameScreen.SetActive(true);
        ActiveGameRoomsScreen.SetActive(false);
    }
}
