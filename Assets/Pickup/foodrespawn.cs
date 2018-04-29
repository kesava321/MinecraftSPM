using UnityEngine;
using System.Collections;

public class foodrespawn: MonoBehaviour{

	public int rtime =5;

	void OncollisionEnter()
	{
		this.GetComponent<SphereCollider> ().enabled = false;
		this.GetComponent<MeshRenderer> ().enabled = false;

		Invoke("Respawn", rtime);
	}

	void Respawn()
	{
		this.GetComponent<SphereCollider> ().enabled = true;
		this.GetComponent<MeshRenderer> ().enabled = true;
	}

	void Start(){
	}

	void Update(){
	}

}