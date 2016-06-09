using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandManager : MonoBehaviour {


	public GameObject cardPrefab;
	List<GameObject> cards;
	public float cardSpacing = 1.5f;

	// Use this for initialization
	void Start () {

		cards = new List<GameObject>();

		cards.Add (Instantiate (cardPrefab) as GameObject);
		SortHand ();
	}

	void SortHand()
	{
		Debug.Log ("SortHand");
		float cardCount = cards.Count;
		for (int i = 0; i < cardCount; i++) 
		{
			//Transform pos = cards[i].GetComponent<Transform>();
			Vector2 pos = new Vector2 (-(((cardCount-1) / 2) * cardSpacing) + (i * cardSpacing), transform.position.y);
		
			cards [i].transform.position = pos;
			Debug.Log ("Updated card");
		}
	}




	// Update is called once per frame
	void Update () {
	
	}
}
