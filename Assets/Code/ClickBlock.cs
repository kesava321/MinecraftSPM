using UnityEngine;
using System.Collections;

public class ClickBlock : MonoBehaviour
{

	// This function starts when the mouse cursor is over the GameObject
	void OnMouseOver()
	{
		// If left mouse press
		if (Input.GetMouseButtonDown(0))
		{
			// Display this text in the Console
			Debug.Log("Left button has been clicked");
		}

		// If right mouse press
		if (Input.GetMouseButtonDown(1))
		{
			// Display a message in the Console tab
			Debug.Log("Right button has been clicked");
		}
	}
}