using UnityEngine;
using System.Collections.Generic;

public class InHandHover : MonoBehaviour {

	public bool inHand = true;
	void Start()
	{


	}


	void OnMouseEnter(){
		Debug.Log ("MouseHover");
		transform.Translate(new Vector3(0,1.1f,-15));
	}

	void OnMouseExit(){

		transform.Translate (new Vector3 (0, -1.1f,15));
	}
}
