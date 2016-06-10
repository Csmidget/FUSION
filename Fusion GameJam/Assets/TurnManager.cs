using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	public static TurnManager instance;
	public Player currPlayer;
	public Player enemy;
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
		for (int i = 0; i < 2; i++) 
		{
			if (HandManager.instance.currHand.cards.Count < 10)
			{
				if (HandManager.instance.numBases < 1) 
					HandManager.instance.PushCard (CardController.instance.GetRandomBase ());				
				else 
					if ((HandManager.instance.numModifiers < 2))
						HandManager.instance.PushCard (CardController.instance.GetRandomModifier ());					
				else
						HandManager.instance.PushCard(CardController.instance.GetRandomCard());

			}
		}
		SwitchPlayer ();
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
