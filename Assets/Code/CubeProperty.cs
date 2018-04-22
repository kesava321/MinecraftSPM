using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeProperties : MonoBehaviour {

	MeshFilter meshFilter;
	public Text vertexPrefab;
	string allVs = "";

	// Use this for initialization
	void Start () {
		//meshfilter for the cube
		meshFilter = this.GetComponent<MeshFilter>(); 

		GameObject canvas = GameObject.FindWithTag("MainCanvas");
		Debug.Log("Vertices------");
		int c = 0;
		//loops through all the meshes in the mesheses vertices array  
		foreach(Vector3 v in meshFilter.mesh.vertices) 
		{
			//prints out vectors and assigns it to the cube, so it can viewed on screen
			Debug.Log(v);
			string vname = v + "";

			Text vertexLabel;
			if(!GameObject.Find(vname))
			{
				vertexLabel = Instantiate(vertexPrefab, Vector3.zero, Quaternion.identity ) as Text;
				vertexLabel.gameObject.name = vname;
				vertexLabel.transform.SetParent(canvas.transform);
				vertexLabel.text = v + ": " + c + "";
				Vector3 vertexLabelPos = Camera.main.WorldToScreenPoint(v + this.transform.position + new Vector3(0,c/80.0f,0));
				vertexLabel.transform.position = vertexLabelPos;

			}
			else
			{
				vertexLabel = GameObject.Find(vname).GetComponent<Text>();
				vertexLabel.text += " " + c; 
			}

			c++;
		}

		//prints out normals
		Debug.Log("Normals-----");
		foreach(Vector3 n in meshFilter.mesh.normals)
		{
			Debug.Log(n);

		}

		//prints out UVs 
		//UVs map a 2d coordinate on a texture onto a vertex
		Debug.Log("UVs------");
		foreach(Vector2 u in meshFilter.mesh.uv)
		{
			Debug.Log(u);
			allVs += u + " ";
		}

		//prints out triangles 
		//array of integers
		Debug.Log("Triangles----");
		foreach(int i in meshFilter.mesh.triangles)
		{
			Debug.Log(i);
			allVs += i + " ";
		}
		Debug.Log(allVs);

	}

	// Update is called once per frame
	void Update () {

	}
}
