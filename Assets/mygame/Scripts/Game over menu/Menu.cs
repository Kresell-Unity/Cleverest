using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void MenuButtonClicked()
	{
		Application.LoadLevel (0);
		Paused.paused = false;
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}