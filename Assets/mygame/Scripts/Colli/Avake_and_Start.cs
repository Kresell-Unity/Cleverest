using UnityEngine;
using System.Collections;

public class Avake_and_Start : MonoBehaviour {
	public GameObject  canvas;
	public GameObject backgtound;
	public GameObject bird;
	public GameObject text_planet;
	public GameObject text;
	public void Awakes ()
	{
		Time.timeScale = 0;
		text_planet.SetActive (true);
		canvas.SetActive (false);
		backgtound.SetActive (false);
		bird.SetActive (false);

		Debug.Log("Awake called.");
	}
	// Use this for initialization
	public void Starts () {

		text_planet.SetActive (false);
		canvas.SetActive (true);
		backgtound.SetActive (true);
		bird.SetActive (true);
		Debug.Log("Start called.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
