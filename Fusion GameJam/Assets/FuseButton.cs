using UnityEngine;
using System.Collections;

public class FuseButton : MonoBehaviour {

	public void OnClick()
	{
		CardFuser.instance.Fuse ();
	}
}
