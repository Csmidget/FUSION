using UnityEngine;
using System.Collections.Generic;

public class InHandHover : MonoBehaviour {

	public bool inHand = true;
	List<SpriteRenderer> renderers;


	void Start()
	{
		renderers = new List<SpriteRenderer> ();

		renderers.Add (this.GetComponent<SpriteRenderer> ());
		foreach (SpriteRenderer sr in this.GetComponentsInChildren<SpriteRenderer> ()) {
			renderers.Add (sr);
		}
	}


	void OnMouseEnter(){
		Debug.Log ("MouseHover");
		foreach (SpriteRenderer sr in renderers) 
		{
			sr.sortingLayerName= "HoverCard";
		}
		transform.Translate(new Vector2(0,2));
	}

	void OnMouseExit(){
		foreach (SpriteRenderer sr in renderers) 
		{
			sr.sortingLayerName= "Default";
		}
		transform.Translate (new Vector2 (0, -2));
	}
}
