using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour {
	//response of character to keyboard movements 
	public float speed = 10.0f;
	// Use this for initialization
	void Start () {
	//turn of cursor on screen and keeps within game window
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		//vertical movement of character
		float vtranslation = Input.GetAxis ("Vertical") * speed;
		//horizontal movement of character 
		float htranslation = Input.GetAxis("Horizontal")*speed;
		//keep movements smooth and keeps in time with update loop
		//delta time is the time between last update and current update
		vtranslation *= Time.deltaTime; 
		htranslation *= Time.deltaTime;

		transform.Translate (htranslation, 0, vtranslation);
		//turns cursor back on if escape key is pressed
		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None; 
		
	}
}
