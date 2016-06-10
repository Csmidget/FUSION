


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandManager : MonoBehaviour {

	public GameObject thisObject;
	public static HandManager instance;
	public GameObject cardPrefab;
	public List<Card> cards;
	public float cardSpacing = 1.5f;
	public int numBases;
	public int numModifiers;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else {
			Destroy (this);
			Debug.Log ("HandManager instance already exists");
		}

	}

	// Use this for initialization
	void Start () {

		cards = new List<Card>();
		AddCard ("CaveMan");
		AddCard ("Spear");
		AddCard ("Goat");
		AddCard ("Oracles Hut");
		AddCard ("Hunting Camp");
		AddCard ("Club");
		AddCard ("Bow");
		SortHand ();
	}

	void AddCard(string cardname)
	{
		Card newCard = CardController.instance.GetCardCopy (cardname);
		newCard.CardObjectTransform.parent = this.transform;
		cards.Add (newCard);
		if (newCard.GetCardType == CardType.Base)
			numBases++;
		else
			numModifiers++;
	}

	public void PushCard(Card _card)
	{
		cards.Add (_card);
		_card.CardObjectTransform.parent = this.transform;
		Debug.Log (cards.Count);
		_card.InHand = true;
		SortHand ();
		if (_card.GetCardType == CardType.Base)
			numBases++;
		else
			numModifiers++;
	}

	public void RemoveCard(Card _card)
	{
		if(cards.Contains(_card))
		{
			cards.Remove (_card);
			Debug.Log ("OH GOD " + cards.Count);
			_card.InHand = false;
			SortHand ();
			if (_card.GetCardType == CardType.Base)
				numBases--;
			else
				numModifiers--;
		}
	}

	public void SortHand()
	{
		Debug.Log ("SortHand");
		float cardCount = cards.Count;
		for (int i = 0; i < cardCount; i++) 
		{
			//Transform pos = cards[i].GetComponent<Transform>();
			Vector3 pos = new Vector3 (this.transform.position.x -(((cardCount-1) / 2) * cardSpacing) + (i * cardSpacing), transform.position.y,-80 + i*3);
		
			cards [i].CardObject.GetComponent<CardMover>().targetLoc = pos;
		}
		return;
	}




	// Update is called once per frame
	void Update () {
	
	}
}
