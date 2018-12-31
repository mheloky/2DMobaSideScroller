using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using TCPIPGame.Messages;
using UnityEngine;
using UnityEngine.UI;

public class IndividualGameRoomScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();

    private int _roomID;
    public Text txtPlayerNameTemplate;
    public GameObject content;
    public NetworkManager TheNetworkManager;
    public bool isVisible = false;


    // Use this for initialization
    void Start () {
        theUIPresenter.Initialize(this.gameObject, isVisible);
        TheNetworkManager.OnGetGameRoomPlayersResponseReceived += TheNetworkManager_OnGetGameRoomPlayersResponseReceived;
        TheNetworkManager.SendMessageToServer(new MessageGetGameRoomPlayersRequest(_roomID));
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void TheNetworkManager_OnGetGameRoomPlayersResponseReceived(object sender, MessageGetGameRoomPlayersResponse e)
    {
        var gameRoomPlayers = e.GameRoomPlayers;
        for (int i = 0; i < gameRoomPlayers.Count; i++)
        {
            var theGameRoomPlayer = gameRoomPlayers[i]; 
             var item = Instantiate(btnGameRoomTemplate);
            item.SetRoomID(theGameRoom.GetRoomID());
            item.SetRoomName(theGameRoom.GetRoomName());
            item.SetText(theGameRoom.GetRoomName());
            item.transform.parent = content.transform;
            item.transform.localPosition = Vector3.zero;
        }
    }

    public void SetRoomID(int roomID)
    {
        _roomID = roomID;
    }

    public int GetRoomID()
    {
        return _roomID;
    }
}
