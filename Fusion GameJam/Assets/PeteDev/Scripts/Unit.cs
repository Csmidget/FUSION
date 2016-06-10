using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
	//needs to edit the stats of the basecard when an event happens, such as health when attacked

	//public GameObject m_tileRef;

	Card m_cardStats;

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
		
	public Card M_cardStats {
		get {
			return m_cardStats;
		}
		set {
			m_cardStats = value;
		}
	}
}
