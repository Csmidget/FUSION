using UnityEngine;
using System.Collections.Generic;

public class Player {

	public int resources;
	public Hand hand;

	public List<Unit> ownedUnits;

	public Player(Hand _hand)
	{
		resources = 5;
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

}
