using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using Assets.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TCPIPGame.Messages;
using TCPIPGame.Server.DomainObjects;
using UnityEngine;
using UnityEngine.UI;

public class IndividualGameRoomScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();

    private int _roomID;
    public Text txtPlayerNameTemplate;
    public GameObject content;
    public inputFieldMessage TheInputFieldMessage;
    public NetworkManager TheNetworkManager;
    public MainThreadSyncronizer TheMainThreadSyncronizer;
    public bool isVisible = false;


    // Use this for initialization
    void Start () {
        theUIPresenter.Initialize(this.gameObject, isVisible);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Setup()
    {
        TheInputFieldMessage.Setup();
        TheNetworkManager.OnGetGameRoomPlayersResponseReceived += TheNetworkManager_OnGetGameRoomPlayersResponseReceived;
        TheNetworkManager.SendMessageToServer(new MessageGetGameRoomPlayersRequest(_roomID));
        TheNetworkManager.OnJoinGameRoomResponseReceived += TheNetworkManager_OnJoinGameRoomResponseReceived;
    }

    private void TheNetworkManager_OnGetGameRoomPlayersResponseReceived(object sender, MessageGetGameRoomPlayersResponse e)
    {
       TheMainThreadSyncronizer.Actions.Add(new Action(() =>
       {
           var gameRoomPlayers = e.GameRoomPlayers;
           for (int i = 0; i < gameRoomPlayers.Count; i++)
           {
               var theGameRoomPlayer = gameRoomPlayers[i];
               AddPlayer(theGameRoomPlayer);
           }
       }
       ));
    }

    private void TheNetworkManager_OnJoinGameRoomResponseReceived(object sender, MessageJoinGameRoomResponse e)
    {
        AddPlayer(e.ThePlayerThatJoined);
    }

    private void AddPlayer(APlayer player)
    {
        TheMainThreadSyncronizer.AddNewAction(() =>
        {
            GameRoomStatus.AddPlayer(player);

            var item = Instantiate(txtPlayerNameTemplate);
            item.text = player.GetUserName();
            item.transform.parent = content.transform;
            item.transform.localPosition = Vector3.zero;
        });
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
