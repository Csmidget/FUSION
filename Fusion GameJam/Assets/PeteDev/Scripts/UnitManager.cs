using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour
{
	public GameObject m_unitPrefab;
	public GameObject m_placementindicatorprefab;


	public bool m_isInPlacement;
	List<Unit> m_units;
	List<GameObject> placementIndicatorList;
	public List<Tile> validTiles;
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

	public Unit CreateTownCentre(Tile homeTile)
	{
		GameObject newUnitGO = (GameObject)Instantiate (m_unitPrefab, new Vector3(homeTile.transform.position.x,homeTile.transform.position.y,-1), Quaternion.identity);
		Unit newUnit = newUnitGO.GetComponent<Unit> ();
		newUnitGO.transform.SetParent (homeTile.gameObject.transform);
		newUnit.M_cardStats = CardController.instance.GetCardCopy ("Town Centre");
		newUnit.M_cardStats.CardObject.SetActive (false);
		newUnit.m_tile = homeTile;
		m_units.Add (newUnit);
		return newUnit;
	}

	// Use this for initialization
	void Start ()
	{
		placementIndicatorList = new List<GameObject> ();
		m_units = new List<Unit> ();
		m_isInPlacement = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void FindValidTiles()
	{
		foreach (Unit u in m_units) {
			if (u.M_cardStats.GetSubType == SubType.Structure)
				u.m_tile.CheckTiles(u.M_cardStats.Range);
		}

		foreach (Tile t in validTiles) {
			placementIndicatorList.Add((GameObject)Instantiate(m_placementindicatorprefab,t.transform.position,Quaternion.identity));
		}
	}

	public Unit PlaceUnit(Tile _tile)
	{
		GameObject newUnitGO = (GameObject)Instantiate (m_unitPrefab, new Vector3(_tile.transform.position.x,_tile.transform.position.y,-1), Quaternion.identity);
		Unit newUnit = newUnitGO.GetComponent<Unit> ();
		newUnitGO.transform.SetParent (_tile.gameObject.transform);
		newUnit.M_cardStats = CardFuser.instance.fusedCard;
		newUnit.M_cardStats.CardObject.SetActive (false);
		newUnit.m_tile = _tile;
		CardFuser.instance.fusedCard = null;
		this.m_isInPlacement = false;
		HandManager.instance.gameObject.SetActive (true);
		m_units.Add (newUnit);

		foreach (GameObject go in placementIndicatorList) {
			Destroy (go);
		}
		placementIndicatorList.Clear ();
		validTiles.Clear ();
		return newUnit;
	}
}