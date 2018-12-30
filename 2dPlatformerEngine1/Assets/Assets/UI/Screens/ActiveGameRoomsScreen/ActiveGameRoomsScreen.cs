using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ActiveGameRoomsScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public NetworkManager TheNetworkManager;
    public bool isVisible = false;

    // Use this for initialization
    void Start () {
        this.gameObject.SetActive(isVisible);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
