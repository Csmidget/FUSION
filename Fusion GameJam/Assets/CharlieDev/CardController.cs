using UnityEngine;
using System.Collections.Generic;

public class CardController : MonoBehaviour {

	public bool cardWasClicked;
	public static  CardController instance;
	public GameObject cardPrefab;
	Dictionary<string,Card>cardDictionary;
	List<Card> stoneAgeList;
	List<Card> ironAgeList;
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
		ironAgeList = new List<Card> ();
		stoneAgeList = new List<Card> ();
		CreateCards ();
	}

	public Card GetRandomCard()
	{
		List<Card> cardList = GetValidList ();
		int randNum = Random.Range (0, cardList.Count);
		return cardList [randNum].MakeCopy();
	}

	public Card GetRandomModifier()
	{
		List<Card> cardList = GetValidList ();

		int randNum = Random.Range (0, cardList.Count);
		while (cardList [randNum].GetCardType != CardType.Modifier) {
			randNum = Random.Range (0, cardList.Count);
		}

		return cardList [randNum].MakeCopy();
	}



	public Card GetRandomBase()
	{
		List<Card> cardList = GetValidList ();

		int randNum = Random.Range (0, cardList.Count);
		while (cardList [randNum].GetCardType != CardType.Base) {
			randNum = Random.Range (0, cardList.Count);
		}

		return cardList [randNum].MakeCopy();
	}

	public List<Card> GetValidList()
	{
		if (TurnManager.instance.currPlayer.age == "Stone Age")
			return stoneAgeList;
		else if (TurnManager.instance.currPlayer.age == "Iron Age")
			return ironAgeList;
		else
			return stoneAgeList;
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
				2,
				2,
				0,
				0
			));
		stoneAgeList.Add (cardDictionary ["CaveMan"]);

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
				1,
				1,
				1,
				0,
				1,
				0,
				0,
				"Spiky",
				"Speary"
			));
		stoneAgeList.Add (cardDictionary ["Spear"]);

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
				1,
				2,
				0,
				0,
				1,
				0,
				0,
				"Archery",
				"Archer"
			));
		stoneAgeList.Add (cardDictionary ["Bow"]);

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
				0,
				3,
				0,
				0,
				1,
				1,
				0,
				"Defended",
				"Clubby"

			));
		stoneAgeList.Add (cardDictionary ["Club"]);

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
				3,
				2,
				0,
				0
			));
		stoneAgeList.Add (cardDictionary ["Goat"]);

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
				0,
				1,
				1,
				0
			));
		stoneAgeList.Add (cardDictionary ["Hunting Camp"]);

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
				0,
				1,
				0,
				2
			));
		stoneAgeList.Add (cardDictionary ["Oracles Hut"]);

		cardDictionary.Add (
			"Town Centre",
			new Card (
				cardPrefab,
				CardType.Base,
				SubType.Structure,
				"Town Centre",
				SpriteController.instance.GetSprite ("Town"),
				"Your base of\noperations",
				true,
				3,
				0,
				30,
				0,
				0,
				4,
				4
			));

		cardDictionary.Add (
			"Wheel",
			new Card (
				cardPrefab,
				CardType.Modifier,
				SubType.Tool,
				"Wheel",
				SpriteController.instance.GetSprite ("PrimitiveWheel"),
				"+1 speed",
				true,
				0, //range
				0, //attack
				0, //defence
				1, //speed
				2, //cost
				0, //resource gen
				0, //research gen
				"Mobile",
				"Wheeled"
			));
		ironAgeList.Add(cardDictionary["Wheel"]);

		cardDictionary.Add (
			"Peasant",
			new Card (
				cardPrefab,
				CardType.Base,
				SubType.Unit,
				"Peasant",
				SpriteController.instance.GetSprite ("Peasant"),
				"A step up\nfrom cave man",
				true,
				2, //range
				2, //attack
				4, //defence
				2, //speed
				4, //cost
				0, //gen
				0
			));
		ironAgeList.Add(cardDictionary["Peasant"]);	

		Debug.Log (cardDictionary.Count);	
	}
}
