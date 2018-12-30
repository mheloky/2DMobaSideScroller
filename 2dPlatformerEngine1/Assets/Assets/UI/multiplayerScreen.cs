using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class multiplayerScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();
    public NetworkManager TheNetworkManager;

    Timer timer = new Timer();
    public bool isVisible = false;

    // Use this for initialization
    void Start () {
        this.gameObject.SetActive(isVisible);
        timer.Interval = 10;
        timer.Elapsed += Timer_Elapsed;
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //TheNetworkHub
    }

    // Update is called once per frame
    void Update () {
		
	}
}
