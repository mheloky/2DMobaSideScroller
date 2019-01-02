using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupMenuScreen : MonoBehaviour {

    public UIPresenter theUIPresenter = new UIPresenter();

    public bool isVisible = false;

    // Use this for initialization
    void Start () {
        this.gameObject.SetActive(isVisible);
        //SceneManager.LoadScene("Moba01-01-2019", LoadSceneMode.Single);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
