using UnityEngine;
using System.Collections;

public class Move1 : MonoBehaviour {
	public GameObject planet;
	public int x = 3, y = 3, z = 1;
	public Vector3 pointB;
	public float speed;


	IEnumerator Start () {

		Vector3 pointA = transform.position;

		while (true) {

			yield return StartCoroutine(MoveObject(transform, pointA, pointB, (float) 3.0));
			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, (float) 3.0));

		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (true) {

			if(!Paused.paused){
				i += Time.deltaTime * rate;

				thisTransform.position = Vector3.Lerp (startPos, endPos, i * speed);}

			if(this.gameObject.transform.position.x == 0 && this.gameObject.transform.position.y == 0)
			{
				Destroy (this.gameObject);
			}

				yield return null; 	
			
		}
	}
}
