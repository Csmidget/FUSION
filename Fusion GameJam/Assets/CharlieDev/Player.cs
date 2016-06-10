using UnityEngine;
using System.Collections.Generic;

public class Player {

	public Hand hand;
	public List<Unit> ownedUnits;

	public Player(Hand _hand)
	{
		hand = _hand;
	}



}
