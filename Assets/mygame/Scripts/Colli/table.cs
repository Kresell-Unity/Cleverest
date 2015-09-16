using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class table : MonoBehaviour {
	public Text record1;
	public Text record2;
	public Text record3;
	// Use this for initialization
	void Start () {
		record1.text= "score: "+PlayerPrefs.GetInt("Score1")+"\n time: "+PlayerPrefs.GetString("Timer1");
		record2.text= "score: "+PlayerPrefs.GetInt("Score2")+"\n time: "+PlayerPrefs.GetString("Timer2");
		record3.text= "score: "+PlayerPrefs.GetInt("Score3")+"\n time: "+PlayerPrefs.GetString("Timer3");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
