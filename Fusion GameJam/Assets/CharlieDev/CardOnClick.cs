using UnityEngine;
using System.Collections;

public class CardOnClick : MonoBehaviour {

	public Card thisCard;

	void OnMouseDown()
	{
		if (thisCard.GetCardType == CardType.Base && thisCard.InHand)
			CardFuser.instance.ChangeBase (thisCard);
		else if (thisCard.GetCardType == CardType.Modifier && thisCard.InHand)
			CardFuser.instance.AddModifier (thisCard);
		else if (thisCard.GetCardType == CardType.Base)
			CardFuser.instance.RemoveBase();
		else if (thisCard.GetCardType == CardType.Modifier)
			CardFuser.instance.RemoveModifier (thisCard);
		
	}
}
