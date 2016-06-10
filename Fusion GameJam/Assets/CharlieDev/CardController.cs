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
			new Modifier(
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
			new Modifier(
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
			new Modifier(
				cardPrefab,
				CardType.Modifier,
				SubType.Tool,
				"Club",
				SpriteController.instance.GetSprite("Club"),
				"+1 Range \n+2 Damage",
				true,
				"Defended",
				"Clubby",
				1,
				2,
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
				"This goat makes \n a meat shield",
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
				0,
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
				0,
				0,
				3,
				0
			));

		Debug.Log (cardDictionary.Count);	
	}
}
