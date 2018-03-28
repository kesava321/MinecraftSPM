using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeProperty : MonoBehaviour {

	MeshFilter meshFilter;
	public Text vertexPrefab;
	string allVs = "";

	// Use this for initialization
	void Start () {
		meshFilter = this.GetComponent<MeshFilter>();

		GameObject canvas = GameObject.FindWithTag("MainCanvas");
		Debug.Log("Vertices------");
		int c = 0;
		foreach(Vector3 v in meshFilter.mesh.vertices)
		{
			Debug.Log(v);
			string vname = v + "";

			Text vLabel; //Vertex Label
			if(!GameObject.Find(vname))
			{
				vLabel = Instantiate(vertexPrefab, Vector3.zero, Quaternion.identity ) as Text;
				vLabel.gameObject.name = vname;
				vLabel.transform.SetParent(canvas.transform);
				vLabel.text = v + ": " + c + "";
				Vector3 vertexLabelPos = Camera.main.WorldToScreenPoint(v + this.transform.position + new Vector3(0,c/80.0f,0));
				vLabel.transform.position = vLabelPos;

			}
			else
			{
				vLabel = GameObject.Find(vname).GetComponent<Text>();
				vLabel.text += " " + c; 
			}

			c++;
		}