using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Creatpickupbox : MonoBehaviour {
	
	public GameObject drop;


	private void OnDestroy()

		
				{
		
		Instantiate(drop, transform.position,drop.transform.rotation);
					
				}
		
}