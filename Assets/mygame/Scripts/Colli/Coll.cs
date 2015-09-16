using UnityEngine; 
using System.Collections; 
public class Coll : MonoBehaviour { 

	public Rigidbody2D[] ast;
	public GameObject planet;
	private float a ;
	public Camera main;
	public static Vector3 world;
	public static float asd;

	void Start () {
		
		world = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -6.0f));
		asd = (world.x * -2);
		asd = asd / 30;
		
		planet.transform.localScale = new Vector2 (asd, asd);
		a = asd;
		
	}
	void OnTriggerStay2D(Collider2D other) {
		Debug.Log ("stay");
		Destroy (other.gameObject);
	}
	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("exit");
		Destroy (other.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("enter");
		Destroy (other.gameObject);
		
		if (other.name == "ast1(Clone)"||other.name == "ast7(Clone)"||other.name == "ast8(Clone)"||other.name == "ast10(Clone)"
		    ||other.name == "ast11(Clone)"||other.name == "ast12(Clone)") {
			a += ast[0].mass / 35;
		}
		
		if(other.name == "ast2(Clone)"||other.name == "ast3(Clone)"||other.name == "ast9(Clone)"||other.name == "ast15(Clone)"
		   ||other.name == "ast16(Clone)"||other.name == "ast19(Clone)"||other.name == "ast20(Clone)"){
			a += ast[1].mass/35;
		}
		if(other.name == "ast4(Clone)"||other.name == "ast5(Clone)"||other.name == "ast6(Clone)"||other.name == "ast13(Clone)"
		   ||other.name == "ast14(Clone)"||other.name == "ast17(Clone)"||other.name == "ast18(Clone)"){
			a += ast[3].mass/35;
		}
		
		
		planet.transform.localScale = new Vector2 (a, a);
	}
	}
