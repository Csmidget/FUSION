using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour {

	public static TurnManager instance;
	public Player currPlayer;
	public Player enemy;
	public Text resourceText;
	public Text researchText;
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} 
		else 
		{
			Debug.Log ("TurnManager instance already exists");
			Destroy (this);
		}

	}


	public void EndTurn()
	{
		CardFuser.instance.EmptyFuser ();
		SwitchPlayer ();
		currPlayer.UpdateResources();
		if (currPlayer.research > 20 && currPlayer.age == "Stone Age")
			currPlayer.age = "Iron Age";

		UnitManager.m_instance.RefreshUnits ();

		while (HandManager.instance.currHand.cards.Count < 10) {
			
			if (HandManager.instance.currHand.numBases < 1) 
				HandManager.instance.PushCard (CardController.instance.GetRandomBase ());				
			else 
				if ((HandManager.instance.currHand.numModifiers < 2))
					HandManager.instance.PushCard (CardController.instance.GetRandomModifier ());					
				else
					HandManager.instance.PushCard(CardController.instance.GetRandomCard());			
		}

		resourceText.text = currPlayer.resources.ToString();
		researchText.text = currPlayer.research.ToString ();
	}

	void SwitchPlayer()
	{
		if (currPlayer == PlayerManager.instance.p1) 
		{
			currPlayer = PlayerManager.instance.p2;
			enemy = PlayerManager.instance.p1;
		} 
		else 
		{
			currPlayer = PlayerManager.instance.p1;
			enemy = PlayerManager.instance.p2;
		}

		HandManager.instance.ChangeCurrentHand (currPlayer.hand);
	}

	// Use this for initialization
	void Start () {
		currPlayer = PlayerManager.instance.p1;
		enemy = PlayerManager.instance.p2;
		HandManager.instance.ChangeCurrentHand (currPlayer.hand);
		resourceText.text = currPlayer.resources.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
