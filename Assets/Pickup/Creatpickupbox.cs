using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Creatpickupbox : MonoBehaviour {
	
	public GameObject drop;


	public void GenerateCube()
	{
		
		Instantiate(drop, transform.position,drop.transform.rotation);
					
	}
		
}