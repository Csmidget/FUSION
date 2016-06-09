


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandManager : MonoBehaviour {


	public GameObject cardPrefab;
	List<Card> cards;
	public float cardSpacing = 1.5f;

	// Use this for initialization
	void Start () {

		cards = new List<Card>();
		AddCard ("CaveMan");
		AddCard ("Spear");
		AddCard ("CaveMan");
		SortHand ();
	}

	void AddCard(string cardname)
	{
		Card newCard = CardController.instance.GetCardCopy (cardname);
		newCard.CardObjectTransform.parent = this.transform;
		cards.Add (newCard);
	}

	void SortHand()
	{
		Debug.Log ("SortHand");
		float cardCount = cards.Count;
		for (int i = 0; i < cardCount; i++) 
		{
			//Transform pos = cards[i].GetComponent<Transform>();
			Vector3 pos = new Vector3 (-(((cardCount-1) / 2) * cardSpacing) + (i * cardSpacing), transform.position.y,-80 + i*3);
		
			cards [i].CardObjectTransform.position = pos;
			Debug.Log ("Updated card");
		}
	}




	// Update is called once per frame
	void Update () {
	
	}
}
