using UnityEngine;
using System.Collections;

public class blockcreation: MonoBehaviour{

	public GameObject block;


	void spawn()
	{
		
			
		
		Vector3 blockPos = new Vector3 (this.transform.position.x,
			this.transform.position.y, 
			this.transform.position.z);
		Instantiate (block, blockPos, Quaternion.identity);
	}

	void Start(){
		spawn ();
	}

	void Update(){
	}
}