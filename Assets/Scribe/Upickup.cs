using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Upickup : MonoBehaviour {

	public GameObject[] cells;
	public GameObject instantiate;
	GameObject item;

	AudioClip Musics;
	Image[] Images;
	Image Imagesingle;

	Text index;
	int IndexInt = 0;
	string IndexStr = "";
	int RandomM = 0;
	string RandomStrInt = "";
	string RandomStr = "";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.X)) {
			Pickup ();
		}

	}

	public void Pickup(){
		
		bool isFind = false;

		RandomM = Random.Range (0,6);
		RandomStrInt = RandomM.ToString ();
		RandomStr = "Pictures/" + RandomStrInt;
		print (RandomStr);

		item = Instantiate (instantiate, transform.position, transform.rotation) as GameObject;//获取预制物体
		Imagesingle = item.transform.GetComponent<Image>();									   //获取预制物体的image组件
		Imagesingle.overrideSprite = Resources.Load (RandomStr, typeof(Sprite))as Sprite;	   //动态加载image组件的sprite

		for (int i = 0; i < cells.Length; i++) {
			if (cells [i].transform.childCount > 0) {//判断当前格子是否有物体
				//如果有，并且一样的
				if (Imagesingle.overrideSprite.name == cells [i].transform.GetChild (0).transform.GetComponent<Image>().overrideSprite.name) {
					//判断的是image加载图片的名字
					isFind = true;

					index = cells [i].transform.GetChild (0).transform.GetChild(0).GetComponent<Text>();
					IndexInt = int.Parse(index.text);
					IndexInt += 1;
					IndexStr = IndexInt.ToString();
					index.text = IndexStr;
					Destroy (item);

				}
			}
		}
		if (isFind == false) {
			for (int i = 0; i < cells.Length; i++) {
				if (cells [i].transform.childCount == 0) {
					//当前没有物体,则添加
					item.transform.SetParent(cells[i].transform);
					item.transform.localPosition = Vector3.zero;
					break;
				}
			}
		}
	}

}
