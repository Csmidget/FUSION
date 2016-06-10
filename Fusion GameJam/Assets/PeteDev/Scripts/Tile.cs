using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


    //might be better to manually declare which card is placed on the tile
    // - when card is selected, and tile is clicked, assign selected card as occupant

    [SerializeField]
    GameObject m_occupant;

    public Sprite[] m_sprites;
    public SpriteRenderer m_spriteRendChild;

    public GameObject m_top;
    public GameObject m_bottom;
    public GameObject m_left;
    public GameObject m_right;

    public GameObject m_topRight;
    public GameObject m_topLeft;
    public GameObject m_bottomRight;
    public GameObject m_bottomLeft;

    Collider2D m_col2D;

    //for movement costs, units can have a passive bonus that increases/decreases their
    //movement speed based on the terrain they are on
	void Awake ()
    {
        m_spriteRendChild = GetComponentInChildren<SpriteRenderer>();
        m_col2D = GetComponent<Collider2D>();
	}

    //needs to be called when the tile is clicked
    public bool IsOccupied()
    {
        if (m_occupant != null)
        {
            return true;
        }
        return false;
    }

    public void SetCellNeighbour(int _position, GameObject _neighbour)
    {
        //top
        if(_position == 0)
        {
            m_top = _neighbour;
        }
        //bottom
        if (_position == 1)
        {
            m_bottom = _neighbour;
        }
        //left
        if (_position == 2)
        {
            m_left = _neighbour;
        }
        //right
        if (_position == 3)
        {
            m_right = _neighbour;
        }

        //top left
        if (_position == 4)
        {
            m_topLeft = _neighbour;
        }
        //bottom right
        if (_position == 5)
        {
            m_bottomRight = _neighbour;
        }
        //top right
        if (_position == 6)
        {
            m_topRight = _neighbour;
        }
        //bottom left
        if (_position == 7)
        {
            m_bottomLeft = _neighbour;
        }
    }

    public void SetTileType(int _type)
    {
        m_spriteRendChild.sprite = m_sprites[_type];

        //types will have movement costs
        if (_type == 0)
        {
            //grass
            
        }
        if (_type == 1)
        {
            //hill

        }
        if (_type == 2)
        {
            //forest

        }
        if (_type == 3)
        {
            //mountain

        }
    }

    public void SetTilePosition(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }
    //if mouse is pressed on tile
    void OnMouseDown()
    {
        //- check to see if a card is currently selected (get from singleton)
        //  - if it is, check if tile is empty (no occupant)
        //      - if it is, check if tile is within range of structure
        //          - if it is, place currently selected card on tile (match position)
        //      - if it is not, do not place card (visual feedback?)
        //- if no card selected, show detail about the tile/occupant (or make nothing happen)
        //

        /*  //Will need to include resources later
         * if(CardIsPlaceable)  //check if card is currently in the "placement" stage
         * {
         *      if(TileIsPlaceable)     //Create list of passable tiles, iterate through
         *      {
         *          //place card (occupant variable)
         *      }
         *      else
         *      {
         *          //no movement allowed
         *      }
         * }
         * else
         * {
         *      //show details about tile that has been clicked
         * }
         * */
        //Debug.Log("I've been clicked");
        //m_spriteRendChild.sprite = m_sprites[4];
        //m_bottomRight.GetComponent<Tile>().m_spriteRendChild.sprite = m_sprites[4];
    }

    void FixedUpdate()
    {
        //GetClickedTile();
    }

    public GameObject GetClickedTile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (m_col2D.OverlapPoint(mousePosition))
            {
                Debug.Log("Here");
                return m_col2D.gameObject;
            }
        }
        return null;
    }

    public GameObject GetNeighbour(int _pos)
    {
        if (_pos == 0)
        {
            return m_top;
        }
        if (_pos == 1)
        {
            return m_bottom;
        }
        if (_pos == 2)
        {
            return m_left;
        }
        if (_pos == 3)
        {
            return m_right;
        }
        if (_pos == 4)
        {
            return m_topLeft;
        }
        if (_pos == 5)
        {
            return m_bottomRight;
        }
        if (_pos == 6)
        {
            return m_topRight;
        }
        if (_pos == 7)
        {
            return m_bottomLeft;
        }
        return null;
    }
}
