using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnCreateGameRoom : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public GameObject btnGameRoomTemplate;
    public GameObject ActiveGameRoomsScreen;
    public GameObject SetupGameScreen;
    public bool IsVisible = true;

    //public GameObject content;

    // Use this for initialization
    void Start () {
        theUIPresenter.Initialize(this.gameObject, IsVisible);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click_CreateRoom(string aa)
    {
        SetupGameScreen.SetActive(true);
        ActiveGameRoomsScreen.SetActive(false);

       // var item = Instantiate(btnGameRoomTemplate);
       // item.transform.parent = content.transform;
       // item.transform.localPosition = Vector3.zero;
    }
}
