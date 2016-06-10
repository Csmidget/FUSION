using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	public static TurnManager instance;

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
		for (int i = 0; i < 2; i++) 
		{
			if (HandManager.instance.cards.Count < 10)
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
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
