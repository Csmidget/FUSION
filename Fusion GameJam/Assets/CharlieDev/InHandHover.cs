using UnityEngine;
using System.Collections.Generic;

public class InHandHover : MonoBehaviour {

	public bool inHand = true;
	public Card thisCard;
	void Start()
	{


	}


	void OnMouseEnter(){
		if(thisCard.InHand)
		transform.Translate(new Vector3(0,1.1f,-15));
	}

	void OnMouseExit(){
		if(thisCard.InHand)
		transform.Translate (new Vector3 (0, -1.1f,15));
	}
}
