using UnityEngine;
using System.Collections.Generic;

public enum CardType {Modifier,Base};
public enum SubType {Structure,Unit,Tool,Material};

public class Card {

	protected bool inHand;
	protected CardType cardType;
	protected SubType subType;
	protected GameObject cardObject;
	protected Transform cardObjectTransform;
	protected GameObject prefab;
	protected string name;
	protected Sprite cardImage;
	protected string cardText;
	protected bool prefabCard;

	protected int range;
	protected int attack;
	protected int defence;
	protected int speed;


	public Card(GameObject _prefab,CardType _type,SubType _subType, string _name, Sprite _cardImage, string _cardText,bool _prefabCard,int _range,int _attack,int _defence,int _speed)
	{
		inHand = true;
		cardType = _type;
		subType = _subType;
		prefab = _prefab;
		name = _name;
		cardImage = _cardImage;
		cardText = _cardText;
		prefabCard = _prefabCard;
		range = _range;
		attack = _attack;
		defence = _defence;
		speed = _speed;

		if (prefabCard)
			cardObject = prefab;
		else {
			cardObject = GameObject.Instantiate (prefab);
			cardObject.GetComponent<CardOnClick> ().thisCard = this;
			cardObject.GetComponent<InHandHover> ().thisCard = this;
			Debug.Log ("card made");
			
		}

		cardObjectTransform = cardObject.GetComponent<Transform> ();


		List<GameObject> children = new List<GameObject> ();
		foreach (Transform t in cardObject.transform) {
			children.Add (t.gameObject);
		}
		foreach (GameObject c in children) {
			switch (c.name) 
			{
			case "cardpic":
				c.GetComponent<SpriteRenderer> ().sprite = cardImage;
				break;
			case "name":
				c.GetComponent<TextMesh> ().text = name;
				break;
			case "desc":
				c.GetComponent<TextMesh> ().text = _cardText;
				break;
			case "type":
				c.GetComponent<TextMesh> ().text = cardType.ToString();
				break;
			case "defence":
				c.GetComponent<TextMesh> ().text = defence.ToString ();
				break;
			case "attack":
				c.GetComponent<TextMesh> ().text = attack.ToString ();
				break;
			}
		}


	}

	public Card MakeCopy()
	{
		Card newCard = new Card (prefab, cardType, subType, name, cardImage, cardText, false, range, attack, defence, speed);
		return newCard;
	}


	public GameObject CardObject {
		get {
			return cardObject;
		}
	}

	public GameObject Prefab {
		get {
			return prefab;
		}
	}

	public string Name {
		get {
			return name;
		}
	}

	public Sprite CardImage {
		get {
			return cardImage;
		}
	}

	public string CardText {
		get {
			return cardText;
		}
	}

	public Transform CardObjectTransform {
		get {
			return cardObjectTransform;
		}
	}

	public CardType GetCardType {
		get {
			return cardType;
		}
	}

	public SubType GetSubType {
		get {
			return subType;
		}
	}
		
	public bool InHand {
		get {
			return inHand;
		}
		set {
			inHand = value;
		}
	}
}
