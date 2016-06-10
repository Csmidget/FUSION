﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{
	public Transform cardRevealLoc;
	//needs to edit the stats of the basecard when an event happens, such as health when attacked

	//public GameObject m_tileRef;
	public bool hasActed;
	List<Tile> validTiles;
	List<Tile> enemyTiles;
	List<GameObject> travelIndicatorList;
	List<GameObject> enemyIndicatorList;
	Card m_cardStats;
	public Tile m_tile;


	void Start ()
	{
		//m_cardStats.
		validTiles = new List<Tile>();
		enemyTiles = new List<Tile> ();
		travelIndicatorList = new List<GameObject> ();
		enemyIndicatorList = new List<GameObject> ();
		hasActed = true;
	}

	void Update ()
	{
		
	}
		
	void OnMouseDown()
	{
		m_cardStats.GetCardMover.targetLoc = cardRevealLoc.position;
		m_cardStats.CardObject.SetActive (true);

		if(TurnManager.instance.currPlayer.ownedUnits.Contains(this) && hasActed == false)
			{
		//MoveUnit ();
		CheckTiles();
		foreach (Tile t in validTiles) {
			GameObject go = (GameObject)Instantiate (UnitManager.m_instance.m_indicatorprefab, t.transform.position, Quaternion.identity);
			go.transform.parent = t.transform;
			travelIndicatorList.Add(go);
			//travelIndicatorList [travelIndicatorList.Count - 1].transform.SetParent (t.transform);
		}
		foreach (Tile t in enemyTiles) {
			enemyIndicatorList.Add((GameObject)Instantiate(UnitManager.m_instance.m_enemyIndicatorPrefab,t.transform.position,Quaternion.identity));
		}
			}
	}

	public void TakeDamage(int damage)
	{
		m_cardStats.Defence -= damage;
		if (m_cardStats.Defence <= 0) {
			Destroy (m_cardStats.CardObject);
			Destroy (this.gameObject);
			PlayerManager.instance.RemoveUnit (this);
		}
	}

	void OnMouseUp()
	{
		m_cardStats.CardObject.SetActive (false);
		if (TurnManager.instance.currPlayer.ownedUnits.Contains (this)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (validTiles.Count > 0) {
				for (int i = 0; i < validTiles.Count; i++) {
					if (validTiles [i].m_col2D.OverlapPoint (mousePosition)) {
						//move unit
						Debug.Log ("MOVED");
						m_tile.m_occupant = null;
						validTiles [i].m_occupant = this;
						transform.SetParent (validTiles [i].transform);
						m_tile = validTiles [i];
						transform.localPosition = new Vector3 (0, 0, -1);
						hasActed = true;
					}
				}
			}
			if (enemyTiles.Count > 0) 
			{
				for (int i = 0; i < enemyTiles.Count; i++) {
					if (enemyTiles [i].m_col2D.OverlapPoint (mousePosition)) 
					{
						enemyTiles [i].m_occupant.TakeDamage(m_cardStats.Attack);
						hasActed = true;
						break;
					}
				}
			}
			validTiles.Clear ();
			enemyTiles.Clear ();
			foreach (GameObject go in travelIndicatorList) {
				Destroy (go);
			}

			travelIndicatorList.Clear ();

			foreach (GameObject go in enemyIndicatorList) {
				Destroy (go);
			}
			enemyIndicatorList.Clear ();
		}
	}

	//pass in range
	public void CheckTiles()
	{
		if (!m_tile.IsOccupied () && !validTiles.Contains (m_tile)) {
			//validTiles.Add (m_tile);
		}
		m_tile.CheckMovement (M_cardStats.Speed,validTiles,enemyTiles);
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
