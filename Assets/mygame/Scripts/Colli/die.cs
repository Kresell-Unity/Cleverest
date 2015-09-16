using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class die : MonoBehaviour {
	public GameObject ui;
	public GameObject Game_over;
	public GameObject bird;
	public GameObject planet;
	public GameObject[] ast;
	public Camera main;
	public Vector3 world;
	public float asd;
	public GameObject bt_resume;
	public GameObject bt_pause;
	public static float end_screen;
	public GameObject text_score;
	public GameObject scoretx;
	public GameObject tint;
	
	void Start(){
		for(int i=0;i<ast.Length;i++ )
		ast[i].GetComponent<SpriteRenderer>().enabled=true;

	}
	// Use this for initialization
	void Update () {
		
		world = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -6.0f));
		
		asd = (world.x * -2);
		
		end_screen = asd / 4.862014f;
		
	
		
		if (this.gameObject.transform.lossyScale.x >= end_screen - end_screen / 20 ) {
			for(int i=0;i<ast.Length;i++ )
			ast[i].GetComponent<SpriteRenderer>().enabled=false;
		
		}
		
		if (this.gameObject.transform.lossyScale.x >= end_screen) {
			
			bird.SetActive(false);
			
			planet.SetActive(false);
			PlayerPrefs.SetInt ("YourScore", ManagerScore.score);
			if (ManagerScore.score > PlayerPrefs.GetInt ("Score1")) {
				PlayerPrefs.SetInt ("Score1", ManagerScore.score);
				PlayerPrefs.SetString ("Timer1", ManagerTime.time_game);
				
			}
			if (ManagerScore.score < PlayerPrefs.GetInt ("Score1") && ManagerScore.score > PlayerPrefs.GetInt ("Score2")) {
				PlayerPrefs.SetInt ("Score2",ManagerScore.score);
				PlayerPrefs.SetString ("Timer2", ManagerTime.time_game);
				
			}
			if (ManagerScore.score < PlayerPrefs.GetInt ("Score2") && ManagerScore.score > PlayerPrefs.GetInt ("Score3")) {
				PlayerPrefs.SetInt ("Score3", ManagerScore.score);
				PlayerPrefs.SetString ("Timer3", ManagerTime.time_game);
			}
			world = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -6.0f));
			asd = (world.x * -2);
			double sdf = asd * 4;


			text_score.GetComponent<Text> ().fontSize = (int) sdf;
			scoretx.GetComponent<Text> ().fontSize = (int) sdf;
			text_score.GetComponent<Text>().text=""+PlayerPrefs.GetInt ("YourScore");

			ui.SetActive(true);
			Game_over.SetActive(true);
			bt_pause.SetActive(false);
			bt_resume.SetActive(false);
			tint.SetActive(true);
			
		}
	}
}



		
		
		

