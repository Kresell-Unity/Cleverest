using UnityEngine;
using System.Collections;

public class DestroyByClick : MonoBehaviour {

	private int valuescore;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (!Paused.paused){

			if(hit.collider != null)
			{
				if(hit.collider.gameObject==gameObject){ Destroy(gameObject);
					//ManagerScore.score+=10;
						if(hit.collider.gameObject.name == "ast1(Clone)"||hit.collider.gameObject.name == "ast7(Clone)"||hit.collider.gameObject.name == "ast8(Clone)"||hit.collider.gameObject.name == "ast10(Clone)"
						   ||hit.collider.gameObject.name == "ast11(Clone)"||hit.collider.gameObject.name == "ast12(Clone)")
						{valuescore=1; ManagerScore.score+=valuescore;}

						if(hit.collider.gameObject.name == "ast2(Clone)"||hit.collider.gameObject.name == "ast3(Clone)"||hit.collider.gameObject.name == "ast9(Clone)"||hit.collider.gameObject.name == "ast15(Clone)"
						   ||hit.collider.gameObject.name == "ast16(Clone)"||hit.collider.gameObject.name == "ast19(Clone)"||hit.collider.gameObject.name == "ast20(Clone)")
						{valuescore=2; ManagerScore.score+=valuescore;}
						if(hit.collider.gameObject.name == "ast4(Clone)"||hit.collider.gameObject.name == "ast5(Clone)"||hit.collider.gameObject.name == "ast6(Clone)"||hit.collider.gameObject.name== "ast13(Clone)"
						   ||hit.collider.gameObject.name == "ast14(Clone)"||hit.collider.gameObject.name == "ast17(Clone)"||hit.collider.gameObject.name == "ast18(Clone)"){valuescore=3; ManagerScore.score+=valuescore;}
				}
			}
			} 
		}
	}
}