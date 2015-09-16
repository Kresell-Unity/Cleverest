using UnityEngine; 
using System.Collections; 
public class ColliStay : MonoBehaviour { 
	
	void OnTriggerStay2D(Collider2D other) {
		Debug.Log ("stay");
		Destroy (other.gameObject);
	}
	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("exit");
		Destroy (other.gameObject);
	}

}