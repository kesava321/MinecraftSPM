using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
	int speed = 10;

	void start(){

		this.transform.Rotate(Vector3.up*speed);
	}
}