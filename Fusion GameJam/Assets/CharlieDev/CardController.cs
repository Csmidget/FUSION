using UnityEngine;
using System.Collections.Generic;

public class CardController : MonoBehaviour {

	public bool cardWasClicked;
	public static  CardController instance;
	public GameObject cardPrefab;
	Dictionary<string,Card>cardDictionary;
	public float cardTargetRadius;

	void OnMouseDown()
	{
		cardWasClicked = false;
	}

	void OnMouseUp()
	{
		Debug.Log ("MOUSE UP");
		cardWasClicked = false;
	}

	void Awake()
	{
		if (instance == null)
			instance = this;
		else {
			Destroy (this);
			Debug.Log ("Cardcontroller instance already exists");
		}

		cardDictionary = new Dictionary<string, Card> ();
		cardTargetRadius = 0.01f;
		CreateCards ();

	}


	// Use this for initialization
	void Start () {
		
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
				"+1 Range \n+1 Damage\n+1 Defence",
				true,
				"Spiky",
				"Speary",
				1,
				1,
				1,
				0
			));
		cardDictionary.Add(
			"Bow",
			new Card(
				cardPrefab,
				CardType.Modifier,
				SubType.Tool,
				"Bow",
				SpriteController.instance.GetSprite("Bow"),
				"+1 Range \n+2 Damage",
				true,
				"Archery",
				"Archer",
				1,
				2,
				0,
				0
			));
		cardDictionary.Add(
			"Club",
			new Card(
				cardPrefab,
				CardType.Modifier,
				SubType.Tool,
				"Club",
				SpriteController.instance.GetSprite("Club"),
				" \n+3 Damage",
				true,
				"Defended",
				"Clubby",
				0,
				3,
				0,
				0
			));
		cardDictionary.Add(
			"Goat",
			new Card(
				cardPrefab,
				CardType.Base,
				SubType.Unit,
				"Goat",
				SpriteController.instance.GetSprite("Goat"),
				"This goat makes\na good meat\nshield",
				true,
				1,
				0,
				3,
				3
			));
		cardDictionary.Add(
			"Hunting Camp",
			new Card(
				cardPrefab,
				CardType.Base,
				SubType.Structure,
				"Hunting Camp",
				SpriteController.instance.GetSprite("StoneAgeHut"),
				"Gathers Resources",
				true,
				2,
				0,
				3,
				0
			));
		cardDictionary.Add(
			"Oracles Hut",
			new Card(
				cardPrefab,
				CardType.Base,
				SubType.Structure,
				"Oracles Hut",
				SpriteController.instance.GetSprite("StoneAgeHut2"),
				"Does Research",
				true,
				2,
				0,
				3,
				0
			));
		cardDictionary.Add(
			"Town Centre",
			new Card(
				cardPrefab,
				CardType.Base,
				SubType.Structure,
				"Town Centre",
				SpriteController.instance.GetSprite("Town"),
				"Your base of\noperations",
				true,
				3,
				0,
				30,
				0
			));

		Debug.Log (cardDictionary.Count);	
	}
}
