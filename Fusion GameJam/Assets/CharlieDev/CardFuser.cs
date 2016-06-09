using UnityEngine;
using System.Collections.Generic;

public class CardFuser : MonoBehaviour {

	public static CardFuser instance;

	public Card baseCard;
	public List<Card> modifiers;

	public GameObject baseCardLoc;
	public GameObject modCardLoc;
	public GameObject resultLoc;


	void Awake()
	{
		if (instance == null)
			instance = this;
		else {
			Destroy (this);
			Debug.Log ("CardFuser instance already exists");
		}

		foreach (GameObject c in transform) {
			switch (c.name) 
			{
			case "BaseCardLoc":
				baseCardLoc = c;
				break;
			case "ModCardLoc":
				modCardLoc = c;
				break;
			case "ResultLoc":
				resultLoc = c;
				break;
			}
		}


	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
