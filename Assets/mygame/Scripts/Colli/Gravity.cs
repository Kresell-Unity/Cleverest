using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	//Strength of attraction from your sphere (obviously, it can be any type of game-object)
	public float StrengthOfAttraction;
	
	//Obviously, you won't be using planets, so change this variable to whatever you want
	public GameObject planet;
	
	//Initialise code:
	void Start () 
	{
		//Again, you can change the tag to whatever you want. 
		//planet = GameObject.FindGameObjectWithTag("planeta");
	}


	//Use FixedUpdate because we are controlling the orbit with physics
	void FixedUpdate () {


		//magsqr will be the offset squared between the object and the planet
		float magsqr;
		
		//offset is the distance to the planet
		Vector3 offset = planet.transform.position;
		
		//get offset between each planet and the player 
		offset = planet.transform.position - transform.position;
		
		//My game is 2D, so I set the offset on the Z axis to 0 
		offset.z = 0;

		//Offset Squared: 
		magsqr = offset.sqrMagnitude;

		//Check distance is more than 0 to prevent division by 0
		if (magsqr > 0.0001f) {

			//Create the gravity- make it realistic through division by the "magsqr" variable 
			GetComponent<Rigidbody2D> ().AddForce ((StrengthOfAttraction * offset.normalized / magsqr) * GetComponent<Rigidbody2D> ().mass);
		}
	
	}
	void Update(){
		Time.timeScale = 1;
		Debug.Log ("scale 1");
		//Declare Variables:
		
		if (Paused.paused) {
			Debug.Log ("scale 0");
			Time.timeScale = 0;
		} 
	}
}

