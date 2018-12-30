using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using TCPIPGame.Messages;
using UnityEngine;
using UnityEngine.UI;

public class btnSetupUsername : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public GameObject EnterUsernameScreen;
    public InputField inputFieldUsername;
    public GameObject ActiveGameRoomScreen;
    public NetworkManager TheNetworkManager;
    public bool IsVisible = true;

	// Use this for initialization
	void Start () {
        theUIPresenter.Initialize(this.gameObject, IsVisible);
        TheNetworkManager.OnConnectedToServerResponseReceived += TheGameClient_OnConnectedToServerResponseReceived;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click_SendUsername(string aa)
    {
       TheNetworkManager.SendMessageToServer(new MessageConnectToServerRequest(inputFieldUsername.text));
       ActiveGameRoomScreen.gameObject.SetActive(true);
       EnterUsernameScreen.SetActive(false);
    }

    private void TheGameClient_OnConnectedToServerResponseReceived(object sender, MessageConnectToServerResponse message)
    {
        Debug.Log("Connected:" + message.Username);
    }
}
