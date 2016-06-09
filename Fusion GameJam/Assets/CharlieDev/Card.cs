using UnityEngine;
using System.Collections.Generic;

public class Card {


	GameObject cardObject;
	Transform cardObjectTransform;
	GameObject prefab;
	string name;
	Sprite cardImage;
	string cardText;
	bool prefabCard;

	public Card(GameObject _prefab,string _name, Sprite _cardImage, string _cardText,bool _prefabCard)
	{
		prefab = _prefab;
		name = _name;
		cardImage = _cardImage;
		cardText = _cardText;
		prefabCard = _prefabCard;

		if (prefabCard)
			cardObject = prefab;
		else
			cardObject = GameObject.Instantiate(prefab);


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
			}
		}


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
}
