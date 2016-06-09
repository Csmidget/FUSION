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
				CardType.Base,
				SubType.Unit,
				"CaveMan",
				SpriteController.instance.GetSprite("CaveMan"),
				"THIS IS CAVEMAN,\n UGG",
				true,
				1,
				1,
				2,
				2
			));

		cardDictionary.Add(
			"Spear",
			new Card(
				cardPrefab,
				CardType.Modifier,
				SubType.Tool,
				"Spear",
				SpriteController.instance.GetSprite("Spear"),
				"THIS IS SPEAR,\n UGG",
				true,
				1,
				0,
				4,
				0
			));


		Debug.Log (cardDictionary.Count);	
	}


	public Card GetCardCopy(string _cardName)
	{
		Debug.Log (_cardName);



		if (cardDictionary.ContainsKey (_cardName)) {
			Card currentCard = cardDictionary [_cardName];
			Card newCard = currentCard.MakeCopy ();
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
