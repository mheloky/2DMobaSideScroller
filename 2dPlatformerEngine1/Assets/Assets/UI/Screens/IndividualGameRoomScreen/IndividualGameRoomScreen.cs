using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualGameRoomScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();

    private int _roomID;
    public Text txtPlayerNameTemplate;
    public NetworkManager TheNetworkManager;
    public bool isVisible = false;


    // Use this for initialization
    void Start () {
        theUIPresenter.Initialize(this.gameObject, isVisible);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetRoomID(int roomID)
    {
        _roomID = roomID;
    }

    public int GetRoomID()
    {
        return _roomID;
    }

    private void GetHostName()
    {
       // TheNetworkManager.
    }
}
