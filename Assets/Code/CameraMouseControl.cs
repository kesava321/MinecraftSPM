using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseControl : MonoBehaviour {

	Vector2 mouseView; //keep track of how much movemetn camera has made.
	Vector2 smoothV; //smooth camera movement 
	public float sensitivity = 4.0f; //sensitivity 
	public float smoothing = 2.0f; //smoothing 

	GameObject character;
	
    // Use this for initialization
	void Start () {
		
        //points back to character
		//character is cameras parent
		character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		var mouseDelta = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		mouseDelta = Vector2.Scale (mouseDelta, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		
        //Lerp is a linear movement of interpretation
		//move smoothly between two points
		smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
		mouseView += smoothV;

		transform.localRotation = Quaternion.AngleAxis (-mouseView.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseView.x, character.transform.up);
	}
}
