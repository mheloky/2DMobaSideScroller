using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnStartGame : MonoBehaviour {

    public NetworkManager TheNetworkManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click(string item)
    {
        GameRoomStatus.TheNetworkManager = TheNetworkManager;
        SceneManager.LoadScene("Moba01-01-2019", LoadSceneMode.Single);
    }
}
