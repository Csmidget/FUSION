using UnityEngine;
using System.Collections.Generic;

public enum CardType {Modifier,Base};
public enum SubType {Structure,Unit,Tool,Material};

public class Card {

	protected bool inHand;
	protected bool inFuser;
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

	string structurePrefix;
	string unitPrefix;

	public Card(Card baseCard, Card mod1, Card mod2)
	{
		inHand = false;
		inFuser = false;
		cardType = CardType.Base;
		subType = baseCard.GetSubType;
		prefab = baseCard.Prefab;
		range 	= 	baseCard.Range;
		attack 	= 	baseCard.Attack;
		defence = 	baseCard.Defence;
		speed 	= 	baseCard.Speed;
		prefabCard = false;
		string prefix1;
		string prefix2;

		if (mod1 != null) {
			range += mod1.Range;
			attack += mod1.Attack;
			defence += mod1.Defence;
			speed += mod1.Speed;

			if (subType == SubType.Structure) {
				Debug.Log ("STRUCTURE");
				prefix1 = mod1.StructurePrefix;
			} else {
				prefix1 = mod1.UnitPrefix;
				Debug.Log ("UNIT");
			}
		} 
		else
			prefix1 = "";
		
		if (mod2 != null)
		{
			range 	+= mod2.Range;
			attack  += mod2.Attack;
			defence += mod2.Defence;
			speed 	+= mod2.Speed;

			if (subType == SubType.Structure)
				prefix2 = mod2.StructurePrefix;
			else
				prefix2 = mod2.UnitPrefix;
		}
		else
			prefix2 = "";

		Debug.Log("prefix1: " + prefix1);
		Debug.Log("prefix2: " + prefix2);
		name = prefix1 + " " + prefix2 + " " + baseCard.Name;
		Debug.Log ("Name:" + name);
		cardImage = baseCard.CardImage;
		cardText = baseCard.CardText;

		cardObject = GameObject.Instantiate (prefab);
		cardObject.GetComponent<CardOnClick> ().thisCard = this;
		cardObject.GetComponent<InHandHover> ().thisCard = this;
		Debug.Log ("card made");

	

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
			c.GetComponent<TextMesh> ().text = cardText;
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



	public Card(GameObject _prefab,CardType _type,SubType _subType, string _name, Sprite _cardImage, string _cardText,bool _prefabCard,int _range,int _attack,int _defence,int _speed)
	{
		inHand = true;
		inFuser = false;
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
		unitPrefix = null;
		structurePrefix = null;

	}

	public Card (GameObject _prefab, CardType _type, SubType _subType, string _name, Sprite _cardImage, string _cardText, bool _prefabCard,string _structurePrefix,string _unitPrefix, int _range,int _attack,int _defence,int _speed) 
	{
		Debug.Log ("SPESHUL CONSTRUCTOR");
		inHand = true;
		inFuser = false;
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

		structurePrefix = _structurePrefix;
		Debug.Log (StructurePrefix);
		unitPrefix = _unitPrefix;
		Debug.Log (UnitPrefix);

	}
	public Card MakeCopy()
	{
		Card newCard = new Card (prefab, cardType, subType, name, cardImage, cardText, false, range, attack, defence, speed);

		if (unitPrefix != null) {
			newCard.UnitPrefix = unitPrefix;
			newCard.StructurePrefix = structurePrefix;
		}
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

	public bool InFuser {
		get {
			return inFuser;
		}
		set {
			inFuser = value;
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

	public int Attack {
		get {
			return attack;
		}
	}

	public int Range {
		get {
			return range;
		}
	}

	public int Defence {
		get {
			return defence;
		}
	}

	public int Speed {
		get {
			return speed;
		}
	}


	public string StructurePrefix {
		get {
			return structurePrefix;
		}
		set {
			structurePrefix = value;
		}
	}

	public string UnitPrefix {
		get {
			return unitPrefix;
		}
		set {
			unitPrefix = value;
		}
	}
}
