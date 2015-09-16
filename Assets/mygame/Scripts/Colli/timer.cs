using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	public float CurrentTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!Paused.paused){
		CurrentTime += Time.deltaTime;
		ManagerTime.time_sec = (CurrentTime);
		if (ManagerTime.time_sec >= 59){
			ManagerTime.time_min += 1;
		CurrentTime = 0;
			}
	}
	}
}
