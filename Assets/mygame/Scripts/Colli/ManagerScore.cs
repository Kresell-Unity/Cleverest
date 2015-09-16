using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerScore : MonoBehaviour
{
	public static int score;  
	public GameObject gameover;// The player's score.
	public Vector3 world;
	public float asd;
	public Camera mainCam;
	Text text;                      // Reference to the Text component.
	

	void Start(){
		world = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -6.0f));
		asd = (world.x * -2);
		double sdf = asd * 4;
		
		this.gameObject.GetComponent<Text> ().fontSize = (int) sdf;
		print (GetComponent<Text> ().fontSize);
	}
	void Awake ()
	{

		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.
		score = 0;
	}
	
	
	void Update ()
	{
	
		PlayerPrefs.SetInt ("YourScore", score);
			if (score > PlayerPrefs.GetInt ("Score1")) {
				PlayerPrefs.SetInt ("Score1", score);
				PlayerPrefs.SetString ("Timer1", ManagerTime.time_game);
		
			}
			if (score < PlayerPrefs.GetInt ("Score1") && score > PlayerPrefs.GetInt ("Score2")) {
				PlayerPrefs.SetInt ("Score2", score);
				PlayerPrefs.SetString ("Timer2", ManagerTime.time_game);

			}
			if (score < PlayerPrefs.GetInt ("Score2") && score > PlayerPrefs.GetInt ("Score3")) {
				PlayerPrefs.SetInt ("Score3", score);
				PlayerPrefs.SetString ("Timer3", ManagerTime.time_game);
			}


		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = ""+ score;
	}
}