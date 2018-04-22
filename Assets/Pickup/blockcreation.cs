using UnityEngine;
using System.Collections;

public class blockcreation: MonoBehaviour{

	public GameObject block;


	void spawn()
	{
		Vector3 blockPos = new Vector3 (this.transform.position.x + Random.Range (-1.0f, 1.0f),
			this.transform.position.y + Random.Range (0.0f, 2.0f),
			this.transform.position.y + Random.Range (0.0f, 2.0f));
		Instantiate (block, blockPos, Quaternion.identity);
	}

	void Start(){
		spawn ();
	}

	void Update(){
	}
}