using UnityEngine;
using System.Collections;

public class MenuGame : MonoBehaviour {

    public GameObject panelGame;
	// Use this for initialization
	void Start () {
	
	}

    public void BtPause() {
        panelGame.SetActive(true);
    }

    public void BtResume()
    {
        panelGame.SetActive(false);
    }

    public void BtMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void BtExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
