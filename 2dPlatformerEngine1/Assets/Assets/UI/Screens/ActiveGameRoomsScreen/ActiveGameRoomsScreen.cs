using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TCPIPGame.Messages;
using UnityEngine;
using UnityEngine.UI;

public class ActiveGameRoomsScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public NetworkManager TheNetworkManager;
    public GameObject content;
    public btnGameRoomTemplate btnGameRoomTemplate;
    public MainThreadSyncronizer TheMainThreadSyncronizer;
    public bool isVisible = false;

    // Use this for initialization
    void Start () {
        theUIPresenter.SetVisibility(this.gameObject, false);
    }

    public void Setup()
    {
        TheNetworkManager.SendMessageToServer(new MessageGetGameRoomsRequest());
        TheNetworkManager.OnGetGameRoomsResponseReceived += TheNetworkManager_OnGetGameRoomsResponseReceived;
    }

    private void TheNetworkManager_OnGetGameRoomsResponseReceived(object sender, TCPIPGame.Messages.MessageGetGameRoomsResponse e)
    {
        TheMainThreadSyncronizer.Actions.Add(new System.Action(() =>
        {
            var gameRooms = e.TheGameRooms;
            for (int i = 0; i < gameRooms.Count; i++)
            {
                var theGameRoom = gameRooms[i];
                var item = Instantiate(btnGameRoomTemplate);
                item.SetRoomID(theGameRoom.GetRoomID());
                item.SetRoomName(theGameRoom.GetRoomName());
                item.SetText(theGameRoom.GetRoomName());
                item.transform.parent = content.transform;
                item.transform.localPosition = Vector3.zero;
            }
        }));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
