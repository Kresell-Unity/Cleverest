//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
	public int time;
	public GUIText timer;
	public GameObject text;
	public GameObject Menu;
	
	void Start()
	{
		Menu.SetActive (false);
		StartCoroutine (countdown());
	}
	
	IEnumerator countdown()
	{
		while (time > -2)
		{
			yield return new WaitForSeconds(1);
			
			timer.text = time.ToString();
			
			time -= 1;
			if(time<0){timer.text = "Start";}
		}
		
		//timer.text = "Start";
		text.SetActive (false);
		timer.text = "";
		Menu.SetActive (true);
	}
}
