using UnityEngine;
using System.Collections;

public class size_butt : MonoBehaviour {
	
	public Vector3 world;
	public Vector3 buttonCam;
	public float asd;
	public float xKofButt;
	public float yKofButt;
	public Camera mainCam;
	public Canvas buttons;
	public Vector2 buttt;
	
	// Use this for initialization
	void Start () {
		
		world = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -6.0f));
		asd = (world.x * -2);
		double sdf = asd / 6;
		float xCanSize = world.x;
		float yCanSize = world.y;
		xKofButt = (xCanSize / 1.38f);
		yKofButt = yCanSize / -1.137f;
		buttt.x = buttons.GetComponent<Rect>().width / world.x;
		buttt.y = buttons.GetComponent<Rect>().height / world.y;
		this.gameObject.transform.localScale = new Vector3 ((float) sdf, (float)sdf,1);
		this.gameObject.transform.localPosition = new Vector3 ((float) xKofButt * buttt.x, (float) yKofButt * buttt.y, 0);
		buttonCam = this.gameObject.transform.localPosition;
		
	}
	
}