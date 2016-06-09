using UnityEngine;
using System.Collections.Generic;

public class CardController : MonoBehaviour {

	public static  CardController instance;
	public GameObject cardPrefab;
	Dictionary<string,Card>cardDictionary;


	void Awake()
	{
		if (instance == null)
			instance = this;
		else {
			Destroy (this);
			Debug.Log ("Cardcontroller instance already exists");
		}

		cardDictionary = new Dictionary<string, Card> ();
		CreateCards ();

	}


	// Use this for initialization
	void Start () {
		
	}

	void CreateCards()
	{
		cardDictionary.Add(
			"CaveMan",
			new Card(
				cardPrefab,
				"CaveMan",
				SpriteController.instance.GetSprite("CaveMan"),
				"THIS IS CAVEMAN,\n UGG",
				true
			));

		cardDictionary.Add(
			"Spear",
			new Card(
				cardPrefab,
				"Spear",
				SpriteController.instance.GetSprite("Spear"),
				"THIS IS SPEAR,\n UGG",
				true
			));


		Debug.Log (cardDictionary.Count);	
	}


	public Card GetCardCopy(string _cardName)
	{
		Debug.Log (_cardName);



		if (cardDictionary.ContainsKey (_cardName)) {
			Card currentCard = cardDictionary [_cardName];
			Card newCard = new Card (currentCard.Prefab, currentCard.Name, currentCard.CardImage, currentCard.CardText,false);
			return newCard;
		} 
		else 
		{
			Debug.Log ("Error creating card copy");
			return null;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
