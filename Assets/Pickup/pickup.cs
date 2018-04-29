using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class pickup : MonoBehaviour {

	public GameObject inventoryPanel;
	public GameObject[] inventoryIcons;
	void OnCollisionEnter(Collision collision)
	{
		foreach(Transform child in inventoryPanel.transform)
		{
			if (child.gameObject.tag == collision.gameObject.tag)
			{
				string c = child.Find("test").GetComponent<Text>().text;
				int tcount = System.Int32.Parse(c) + 1;
				child.Find("test").GetComponent<Text>().text = "" + tcount;
				return;
			}
		}

		GameObject i;
		if(collision.gameObject.tag == "grass")
		{
			i = Instantiate(inventoryIcons[0]);
			i.transform.SetParent(inventoryPanel.transform );
		}
		else if(collision.gameObject.tag == "wood")
		{
			i = Instantiate(inventoryIcons[1]);
			i.transform.SetParent(inventoryPanel.transform );
		}
		else if(collision.gameObject.tag == "mud")
		{
			i = Instantiate(inventoryIcons[2]);
			i.transform.SetParent(inventoryPanel.transform );
		}
	
	}
}
