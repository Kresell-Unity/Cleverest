using UnityEngine;
using System.Collections;

public class Paused : MonoBehaviour {
	public static bool paused;
	public GameObject p_butt;
	public GameObject image;
	public GameObject puse_BT;


	// Use this for initialization
	void Start () {
		paused = false;

	}
	public void PauseButtonClick(){
		paused = !paused;
		p_butt.SetActive (false);
		puse_BT.SetActive (true);
		image.SetActive (true);

	}

	public void ResumeButtonClick(){
		p_butt.SetActive (true);
		image.SetActive (false);
		puse_BT.SetActive (false);

		paused = false;
	
	}


}
	

