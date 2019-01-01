using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnGameRoomTemplate : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public int RoomID;
    public string RoomName;
    public GameObject activeGameRoomsScreen;
    public IndividualGameRoomScreen individualGameRoomScreen;
    public bool IsVisible = false;

    // Use this for initialization
    void Start () {
        theUIPresenter.Initialize(this.gameObject, IsVisible);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click (string str)
    {
        individualGameRoomScreen.SetRoomID(RoomID);
        individualGameRoomScreen.Setup();
        activeGameRoomsScreen.SetActive(false);
        individualGameRoomScreen.gameObject.SetActive(true);
    }

    public void SetRoomID(int roomID)
    {
        RoomID = roomID;
    }

    public void SetRoomName(string roomName)
    {
        RoomName = roomName;
    }

    public int GetRoomID()
    {
        return RoomID;
    }

    public string GetRoomName()
    {
        return RoomName;
    }

    public void SetText(string text)
    {
        GetComponentInChildren<Text>().text = text;
    }

    public string GetText(string text)
    {
        return GetComponentInChildren<Text>().text;
    }
}
