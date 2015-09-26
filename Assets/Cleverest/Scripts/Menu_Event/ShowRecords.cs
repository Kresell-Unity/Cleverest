using UnityEngine;
using System.Collections;

public class ShowRecords : MonoBehaviour {

	public GameObject Showpanel;
	public GameObject MenuPanel;
	// Use this for initialization
	void Start () {
		Showpanel.SetActive (false);
	}

	public void RecordsButtonClicked()
	{
		Showpanel.SetActive (true);
		MenuPanel.SetActive (false);	
	}
	public void BackButtonClicked()
	{
		Showpanel.SetActive (false);
		MenuPanel.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
