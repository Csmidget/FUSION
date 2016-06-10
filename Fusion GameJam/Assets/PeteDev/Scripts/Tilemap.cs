using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tilemap : MonoBehaviour {

    [SerializeField]
    GameObject m_tile;

    List<GameObject> m_gridCells;

    int m_height, m_width;
    float m_tileOffset;

	void Start ()
    {
        m_height = 16;
        m_width = 30;
        m_tileOffset = 0.5f;

        m_gridCells = new List<GameObject>();
        GenerateMap();  //call method
	}

    void GenerateMap()
    {
        GameObject cur_cell;
        GameObject other_cell;

        for (int y = 0; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                cur_cell = Instantiate(m_tile) as GameObject;
                Tile curCellScript = cur_cell.GetComponent<Tile>();

                //horizontal
                if (x > 0)
                {
                    other_cell = m_gridCells[m_gridCells.Count - 1];
                    Tile otherCellScript = other_cell.GetComponent<Tile>();

                    otherCellScript.SetCellNeighbour(3, cur_cell);
                    curCellScript.SetCellNeighbour(2, other_cell);

                    if (y > 0)
                    {
                        other_cell = m_gridCells[m_gridCells.Count - m_width - 1];
                        otherCellScript = other_cell.GetComponent<Tile>();
                        curCellScript = cur_cell.GetComponent<Tile>();

                        otherCellScript.SetCellNeighbour(6, cur_cell);
                        curCellScript.SetCellNeighbour(7, other_cell);
                    }
                }
                if (y > 0)
                {
                    other_cell = m_gridCells[m_gridCells.Count - m_width];
                    Tile otherCellScript = other_cell.GetComponent<Tile>();

                    otherCellScript.SetCellNeighbour(0, cur_cell);
                    curCellScript.SetCellNeighbour(1, other_cell);
                }

                if (y > 0 && y < m_height && x < m_width - 1)
                {
                    other_cell = m_gridCells[m_gridCells.Count - m_width + 1];
                    Tile otherCellScript = other_cell.GetComponent<Tile>();

                    otherCellScript.SetCellNeighbour(4, cur_cell);
                    curCellScript.SetCellNeighbour(5, other_cell);
                }

                curCellScript.SetTilePosition((x * m_tileOffset) + (m_tileOffset / 2), (y * m_tileOffset) - (m_tileOffset));
                curCellScript.SetTileType(Random.Range(0, 4));

                m_gridCells.Add(cur_cell);
                m_gridCells[m_gridCells.Count - 1].transform.SetParent(transform);
            }
        }
    }

    /*void GenerateMap()
    {
        GameObject cur_cell;
        GameObject other_cell;

        for (float y = 0; y < m_height; y++)
        {
            for (float x = 0; x < m_width; x++)
            {
                GameObject obj = ObjectPooler.m_current.GetPooledObject();

                if (obj == null)
                {
                    return;
                }

                obj.transform.position = new Vector2((x * m_tileOffset) + (m_tileOffset / 2), (y * m_tileOffset) - (m_tileOffset / 2));
                obj.transform.rotation = transform.rotation;
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponentInChildren<Tile>().SetTileType(Random.Range(0, 4));
                obj.SetActive(true);
            }
        }
    }*/
}
