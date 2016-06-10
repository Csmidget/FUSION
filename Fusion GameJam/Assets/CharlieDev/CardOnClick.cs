using UnityEngine;
using System.Collections;

public class CardOnClick : MonoBehaviour {

	public Card thisCard;

	void OnMouseDown()
	{
		if (thisCard.GetCardType == CardType.Base && thisCard.InHand)
			CardFuser.instance.ChangeBase (thisCard);
			
	}
}
