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

    }
}
