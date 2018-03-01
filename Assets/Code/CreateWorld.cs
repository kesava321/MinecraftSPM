using UnityEngine;
using System.Collections;

public class CreateWorld : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public static void CloneAndPlace(Vector3 newPosition, 
		GameObject intitalGameobject)
	{
		// Clone
		GameObject clone = (GameObject)Instantiate(intitalGameobject, newPosition, Quaternion.identity);
		// Place
		clone.transform.position = newPosition;
		// Rename
		clone.name = "Voxel@" + clone.transform.position;
	}
}