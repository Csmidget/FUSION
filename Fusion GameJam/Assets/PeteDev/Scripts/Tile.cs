using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {


    //might be better to manually declare which card is placed on the tile
    // - when card is selected, and tile is clicked, assign selected card as occupant

    [SerializeField]
    GameObject m_occupant;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
	    
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
