using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
	public Transform cardRevealLoc;
	//needs to edit the stats of the basecard when an event happens, such as health when attacked

	//public GameObject m_tileRef;

	Card m_cardStats;
	public Tile m_tile;


	void Start ()
	{
		//m_cardStats.
	}

	void Update ()
	{
		
	}

	void ChangeStat(int _mod)
	{

	}
		
	void OnMouseDown()
	{
		m_cardStats.GetCardMover.targetLoc = cardRevealLoc.position;
		m_cardStats.CardObject.SetActive (true);
	}
	void OnMouseUp()
	{
		m_cardStats.CardObject.SetActive (false);
	}


	public Card M_cardStats {
		get {
			return m_cardStats;
		}
		set {
			m_cardStats = value;
		}
	}
}
