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
		baseCard = null;
	}

	public void ChangeBase(Card _baseCard)
	{
		if (baseCard != null) 
		{
			HandManager.instance.PushCard (baseCard);
		}
		HandManager.instance.RemoveCard (_baseCard);
		_baseCard.CardObjectTransform.parent = baseCardLoc.transform;
		_baseCard.CardObjectTransform.localPosition = Vector3.zero;
		baseCard = _baseCard;
		Debug.Log ("ChangedBase");
	}

	public

	void UpdateResult()
	{
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
