using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using TCPIPGame.Messages;
using UnityEngine;
using UnityEngine.UI;

public class btnSetupGameRoom : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public bool IsVisible = true;
    public GameObject IndividualGameRoomScreen;
    public InputField InputFieldGameRoomName;
    public NetworkManager TheNetworkManager;

	// Use this for initialization
	void Start () {
        theUIPresenter.Initialize(this.gameObject, IsVisible);
        TheNetworkManager.OnCreateRoomResponseReceived += TheNetworkManager_OnCreateRoomResponseReceived;
    }
-
    // Update is called once per frame
    void Update () {
		
	}

    public void Click(string str)
    {
        TheNetworkManager.SendMessageToServer(new MessageCreateRoomRequest(InputFieldGameRoomName.text));
    }

    private void TheNetworkManager_OnCreateRoomResponseReceived(object sender, MessageCreateRoomResponse e)
    {
        Debug.Log(string.Format("Response Received-Created Game Room:{0}", e.RoomName));
    }
}
