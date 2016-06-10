using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager instance;

	public Hand p1Hand;
	public Hand p2Hand;

	public Player p1;
	public Player p2;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else {
			Debug.Log ("PlayerManager instance already found");
			Destroy (this);
		}
	}

	void Start()
	{
		p1 = new Player (p1Hand);
		p2 = new Player (p2Hand);

		HandManager.instance.currHand = p1.hand;
		HandManager.instance.SetupHand ();
		HandManager.instance.ChangeCurrentHand(p2.hand);
		HandManager.instance.SetupHand ();
	}

}
