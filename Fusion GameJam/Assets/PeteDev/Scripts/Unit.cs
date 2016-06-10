using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{
	public Transform cardRevealLoc;
	//needs to edit the stats of the basecard when an event happens, such as health when attacked

	//public GameObject m_tileRef;

	List<Tile> validTiles;
	List<GameObject> travelIndicatorList;
	Card m_cardStats;
	public Tile m_tile;


	void Start ()
	{
		//m_cardStats.
		validTiles = new List<Tile>();
		travelIndicatorList = new List<GameObject> ();
	}

	void Update ()
	{
		
	}
		
	void OnMouseDown()
	{
		m_cardStats.GetCardMover.targetLoc = cardRevealLoc.position;
		m_cardStats.CardObject.SetActive (true);

		//MoveUnit ();
		CheckTiles();
		foreach (Tile t in validTiles) {
			travelIndicatorList.Add((GameObject)Instantiate(UnitManager.m_instance.m_indicatorprefab,t.transform.position,Quaternion.identity));
		}
	}

	void OnMouseUp()
	{
		m_cardStats.CardObject.SetActive (false);

		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (validTiles.Count > 0) {
			for (int i = 0; i < validTiles.Count; i++) {
				if (validTiles [i].m_col2D.OverlapPoint (mousePosition)) {
					//move unit
					Debug.Log("MOVED");
					m_tile.m_occupant = null;
					validTiles[i].m_occupant = this;
					transform.SetParent (validTiles [i].transform);
					m_tile = validTiles [i];
					transform.localPosition = Vector2.zero;

				}
			}
		}
		validTiles.Clear ();
		foreach (GameObject go in travelIndicatorList) {
			Destroy (go);
		}
		travelIndicatorList.Clear ();
	}

	//pass in range
	public void CheckTiles()
	{
		if (!m_tile.IsOccupied () && !validTiles.Contains (m_tile)) {
			//validTiles.Add (m_tile);
		}
		m_tile.CheckMovement (M_cardStats.Speed,validTiles);
		Debug.Log ("Num valid tiles: " + validTiles.Count);
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
