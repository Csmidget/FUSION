using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {


    //might be better to manually declare which card is placed on the tile
    // - when card is selected, and tile is clicked, assign selected card as occupant

    [SerializeField]
    GameObject m_occupant;

    public Sprite[] m_sprites;
    SpriteRenderer m_spriteRendChild;

    public GameObject m_top;
    public GameObject m_bottom;
    public GameObject m_left;
    public GameObject m_right;

    public GameObject m_topRight;
    public GameObject m_topLeft;
    public GameObject m_bottomRight;
    public GameObject m_bottomLeft;
    

	void Awake ()
    {
        m_spriteRendChild = GetComponentInChildren<SpriteRenderer>();
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

        /*
         * if(GameState.m_instance.isCardSelected == true)
         * {
         *      if(!IsOccupied)
         *      {
         *          if(GameState.m_instance.resourceCount > GameState.m_instance.GetCurrentCard().GetResourceCost())    //turn into method in Singleton, call it here
         *          {
         *              //will need to iterate through each tile
         *              if(Vector2.Distance(transform.position, structure.transform.position) < threshold)
         *              {
         *                  //place card
         *                  m_occupant = Gamestate.m_instance.GetCurrentCard();
         *                  //set icon here
         *              }
         *          }
         *      }
         *      else
         *      {
         *          //card cannot be placed (show visual, send event?)
         *      }
         * }
         * else
         * {
         *      //show detail about tile being clicked
         * }
         * */
    }
}
