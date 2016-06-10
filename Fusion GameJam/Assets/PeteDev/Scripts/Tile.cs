using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


    //might be better to manually declare which card is placed on the tile
    // - when card is selected, and tile is clicked, assign selected card as occupant

    [SerializeField]
    Unit m_occupant;

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

	public SubType GetOccupantType()
	{
		return m_occupant.GetComponent<Unit> ().M_cardStats.GetSubType;
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

    void Update()
    {
       // GetClickedTile();
    }

	public void CheckTiles(int distanceAway)
	{
		if (distanceAway <= 0)
			return;
		else 
		{
			distanceAway -= 1;
			if(!IsOccupied() && !UnitManager.m_instance.validTiles.Contains(this))
			UnitManager.m_instance.validTiles.Add (this);

			for (int i = 0; i <= 7; i++) 
			{
				GetNeighbour (i).GetComponent<Tile>().CheckTiles (distanceAway);
			}
		}

	}

	void OnMouseDown()
	{
		//if (CardController.instance.cardWasClicked == false) {
			//Debug.Log("Here");
			//return m_col2D.gameObject;
		if (UnitManager.m_instance.m_isInPlacement && UnitManager.m_instance.validTiles.Contains(this)) {
				//TODO mountains
				if (!IsOccupied ()) {
					m_occupant = UnitManager.m_instance.PlaceUnit (this);
				}
			}

	}

    public GameObject GetClickedTile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (m_col2D.OverlapPoint (mousePosition) && CardController.instance.cardWasClicked == false) {
				//Debug.Log("Here");
				//return m_col2D.gameObject;
				if (UnitManager.m_instance.m_isInPlacement) {
					//TODO mountains
					if (!IsOccupied ()) {
						m_occupant = UnitManager.m_instance.PlaceUnit (this);
					}
				}
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
