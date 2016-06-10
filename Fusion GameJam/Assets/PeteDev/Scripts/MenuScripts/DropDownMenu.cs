using UnityEngine;
using System.Collections;

public class DropDownMenu : MonoBehaviour
{
	//start -320, 320 Y
	//end 0, 0 Y

	//Vector2 m_startPos, m_endPos;
	RectTransform m_rect;

	void Start ()
	{
		m_rect = GetComponent<RectTransform> ();
	}

	void OnMouseEnter()
	{
		//transform.position = Vector2.Lerp(m_startPos, m_endPos
	}

	void OnMouseExit()
	{

	}
}
