using UnityEngine;
using System.Collections.Generic;

public class Player {

	public int resources;
	public int research;
	public Hand hand;
	public string age;
	public List<Unit> ownedUnits;

	public Player(Hand _hand,int startResource)
	{
		resources = startResource;
		ownedUnits = new List<Unit> ();
		hand = _hand;
	}

	public void UpdateResources()
	{
		foreach (Unit u in ownedUnits) 
		{
			resources += u.M_cardStats.ResourceGen;
		}
	}

	public void PayResource(int resourcelost)
	{
		resources -= resourcelost;
		TurnManager.instance.resourceText.text = resources.ToString ();
	}

}
