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
    public txtGameRoom TxtGameRoomTemplate;
    public bool isVisible = false;

    // Use this for initialization
    void Start () {
        theUIPresenter.SetVisibility(this.gameObject, false);
        TheNetworkManager.SendMessageToServer(new MessageGetGameRoomsRequest());
        TheNetworkManager.OnGetGameRoomsResponseReceived += TheNetworkManager_OnGetGameRoomsResponseReceived;
    }

    private void TheNetworkManager_OnGetGameRoomsResponseReceived(object sender, TCPIPGame.Messages.MessageGetGameRoomsResponse e)
    {
        var gameRooms = e.TheGameRooms;
        for (int i = 0; i < gameRooms.Count; i++)
        {
            var theGameRoom = gameRooms[i];
            var item = Instantiate(TxtGameRoomTemplate);
            item.SetText(theGameRoom.GetRoomName());
            item.transform.parent = content.transform;
            item.transform.localPosition = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
