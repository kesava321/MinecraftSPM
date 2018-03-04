using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlockToInventory : MonoBehaviour
{

    // represents the difference in position of the positions new instance
    public Vector3 delta;

    // This function starts when the mouse cursor is over the GameObject
    void OnMouseOver()
    {
        // If left mouse press
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left button has been clicked");

            // Destroy the parent of the face we clicked
            Destroy(this.transform.parent.gameObject);
        }
			
	// If right mouse press
	if (Input.GetMouseButtonDown(1))
	{
		Debug.Log("Right button has been clicked");
		// Call method from CreateWorld class
		CreateWorld.CloneAndPlace(this.transform.parent.transform.position + delta, // N (center of new instance)= C (center of the cube) + delta
			this.transform.parent.gameObject); // The parent GameObject
	}
}
}
