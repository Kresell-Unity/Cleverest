using UnityEngine;
using System.Collections;

public class Sizes : MonoBehaviour {

	public GameObject planet;
	public Camera main;
	public static Vector3 world;
	public static float asd;
	public Sprite[] planet_skins = new Sprite[10];
	
	void Start () {
		
		world = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -6.0f));
		asd = (world.x * -2);
		planet.GetComponent<SpriteRenderer> ().sprite = planet_skins [Random.Range (0, planet_skins.Length)];
		planet.transform.localScale = new Vector2 (asd / 30, asd / 30);
		
	}
}
