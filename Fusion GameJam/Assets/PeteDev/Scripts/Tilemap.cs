using UnityEngine;
using System.Collections;

public class Tilemap : MonoBehaviour {

    int m_height, m_width;
    float m_tileOffset;

	void Start ()
    {
        m_height = 16;
        m_width = 30;
        m_tileOffset = 0.5f;

        GenerateMap();  //call method
	}

    void GenerateMap()
    {

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
