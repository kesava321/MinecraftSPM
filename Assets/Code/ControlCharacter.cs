using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour {

	//Response of character
	public float speed = 10.0F; 
	// Use this for initialization
	void Start () {
	//turn of cursor and stay within screen
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		//forward/backward movement
		float translation = Input.GetAxis ("Vertical") * speed;
		//side to side movement
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		//straffe across x-axsis and translate across z-axis
		transform.Translate (straffe, 0, translation);
		//if escape key is pressed turn mouste lock state back on 
		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;
	}
}
