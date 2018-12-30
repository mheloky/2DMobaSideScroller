using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TCPIPGame.Client;
using TCPIPGame.Messages;
using UnityEngine;
using UnityEngine.UI;

public class btnMultiplayer : MonoBehaviour {

    private bool isClicked = false;
    public GameObject StartMenu;
    public GameObject EnterNameScreen;
    public NetworkManager TheNetworkManager;

    // Use this for initialization
    void Start () {

        TheNetworkManager.OnPreConnectedToServerResponseReceived += TheGameClient_OnPreConnectedToServerResponseReceived;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
       /* if(TheNetworkHub != null &&
           TheNetworkHub.GetGameClientStatus().GetIsPreConnected())
        {
            StartMenu.SetActive(false);
            EnterNameScreen.SetActive(true);
        }
        else
        {
            StartMenu.SetActive(true);
            EnterNameScreen.SetActive(false);
        }*/
    }

    public bool GetIsClicked()
    {
        return isClicked;
    }

    public void Click(String nothing)
    {
        TheNetworkManager.Connect();
        StartMenu.SetActive(false);
        EnterNameScreen.SetActive(true);
    }

    private void TheGameClient_OnPreConnectedToServerResponseReceived(object sender, MessagePreConnectToServerResponse message)
    {
        Debug.Log(String.Format("PreConnected Succesfully?:{0}",message.Connected));
    }
}
