using UnityEngine;
using System.Collections;

public class FuseButton : MonoBehaviour {

	public GameObject endTurnButton;

	public void OnClick()
	{
		CardFuser.instance.Fuse ();
		UnitManager.m_instance.m_isInPlacement = true;
		UnitManager.m_instance.FindValidTiles ();
		HandManager.instance.currHand.gameObject.SetActive (false);
		endTurnButton.SetActive (false);
	}
}
