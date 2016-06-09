using UnityEngine;
using System.Collections;

public class Tilemap : MonoBehaviour {

    /*
     *  For loop X and Y to make the tile map
     *  
     * 
     * Position camera at 6.5, 3.5, -10
     * */

    int m_height, m_width;

	void Start ()
    {
        m_height = 8;
        m_width = 14;

        GenerateMap();  //call method
	}

    void GenerateMap()
    {
        for (int y = 0; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                GameObject obj = ObjectPooler.m_current.GetPooledObject();

                if (obj == null)
                {
                    return;
                }

                obj.transform.position = new Vector2(x, y);
                obj.transform.rotation = transform.rotation;
                obj.SetActive(true);
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }
}
