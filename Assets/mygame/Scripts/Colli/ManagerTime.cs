using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerTime : MonoBehaviour
{
	public static float time_sec;       // The player's time.
	public static float time_min;
	public static string time_game;
	public Vector3 world;
	public float asd;
	public Camera mainCam;
	 Text text;                      // Reference to the Text component.
	
	
	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		world = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -6.0f));
		asd = (world.x * -2);
		double sdf = asd *3;
		
		this.gameObject.GetComponent<Text> ().fontSize = (int) sdf;
		print (GetComponent<Text> ().fontSize);
		// Reset the score.
		time_sec = 0;
		time_min = 0;
	}
	
	
	void Update ()
	{
		// Set the displayed text to be the word "Time" followed by the score value.
		if (time_sec < 10&&time_min < 10) {
			time_game=text.text = "0"+time_min + ":0" + (int)time_sec;

		}
		if (time_sec > 10&&time_min < 10) {
			time_game=text.text = "0"+time_min + ":" + (int)time_sec;
		}
	
		if (time_sec > 10&&time_sec < 10) {
			time_game=text.text = time_min + ":0" + (int)time_sec;
		}
		if (time_sec > 10&&time_sec > 10) {
			time_game=text.text = time_min + ":" + (int)time_sec;
		}
	}
}