using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject panel;
	public GameObject resume;
	public GameObject restart;
	// Use this for initialization
	void Start () {
	
	}
	void OnGUI()
	{

		if (Paused.paused) {

			panel.SetActive(true);
			resume.SetActive(true);
			restart.SetActive(true);
			
		} 
		else{
			panel.SetActive(false);
			resume.SetActive(false);
			restart.SetActive(false);


		}
		
	}
	void Update(){
		OnGUI ();
	}
}

