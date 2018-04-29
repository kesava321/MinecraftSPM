using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
	int speed = 10;

	void Update(){

		this.transform.Rotate(transform.up*speed);
	}
}