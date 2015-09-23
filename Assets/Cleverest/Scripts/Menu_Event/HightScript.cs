using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HightScript : MonoBehaviour {

	public GameObject score;
	public GameObject playerName;

	public void SetScore(string name,string score){
		this.playerName.GetComponent<Text> ().text = name;
		this.score.GetComponent<Text> ().text = score;
	}
}
