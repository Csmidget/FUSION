using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour
{
	public GameObject m_unitPrefab;

	public bool m_isInPlacement;
	List<Unit> m_units;

	public static UnitManager m_instance;

	void Awake()
	{
		if (m_instance == null) {
			m_instance = this;
		} else {
			Debug.Log ("Instance Unit Manager already found");
			Destroy (this);
		}
	}

	// Use this for initialization
	void Start ()
	{
		m_units = new List<Unit> ();
		m_isInPlacement = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public Unit PlaceUnit(Tile _tile)
	{
		GameObject newUnitGO = (GameObject)Instantiate (m_unitPrefab, _tile.transform.position, Quaternion.identity);
		Unit newUnit = newUnitGO.GetComponent<Unit> ();
		newUnitGO.transform.SetParent (_tile.gameObject.transform);
//		newUnit.M_cardStats = CardFuser.instance.fusedCard;
//		newUnit.M_cardStats.CardObject.SetActive (false);
//		CardFuser.instance.fusedCard = null;
//		this.m_isInPlacement = false;
		m_units.Add (newUnit);
		return newUnit;
	}
}