using UnityEngine;
using System.Collections;

public class foodcreation: MonoBehaviour{

	public GameObject block;
	int blockNum = 8;

	void spawn()
	{
		for(int i= 0; i<blockNum; i++)
		{
			Vector3 blockPos = new Vector3 (this.transform.position.x+Random.Range(-1.0f,1.0f),
				this.transform.position.y+Random.Range(-1.0f,2.0f), 
				this.transform.position.z+Random.Range(-1.0f,1.0f));
			Instantiate (block, blockPos, Quaternion.identity);
			
		}


	}
		

	void Start(){
		spawn ();
	}

	void Update(){
	}
}