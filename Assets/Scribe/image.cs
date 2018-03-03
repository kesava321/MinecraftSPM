using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;  
using System.IO;  
public class image: MonoBehaviour {  
	public Image img;  
	public RawImage rawImg;  
	public Transform cube;  
	// Use this for initialization  
	void Start () {  
		//Texture2D t = Resources.Load("1") as Texture2D;  
		//bg.sprite = Sprite.Create(t, new Rect(Vector2.zero, new Vector2(t.width, t.height)), Vector2.zero);  
		//Instantiate(Resources.Load("Cube") as GameObject);  

		StartCoroutine(LoadBg());  


	}  

	IEnumerator LoadBg()  
	{  
		WWW www = new WWW(Path.Combine("file://" + Application.streamingAssetsPath, "bg.jpg"));  
		yield return www;  
		Texture2D t = www.texture;  
		//修改了rawimage  
		rawImg.texture = t;  
		//修改了cube  
		cube.GetComponent<MeshRenderer>().material.mainTexture = t;  
		//加载了img  
		Sprite sprite = Sprite.Create(t, new Rect(Vector2.zero, new Vector2(t.width, t.height)), Vector2.zero);  
		img.sprite = sprite;  
		img.SetNativeSize();  
	}  

	// Update is called once per frame  
	void Update () {  

	}  
}  