using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotkey : MonoBehaviour {
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.I)) {
			
					OpenItemMenu();
			gameObject.UI - bag;
				
				}
			}

	public void OpenItemMenu()
			{
				if (!UI-bag)
				{
					Time.timeScale = 0;
				}
				else
				{
					Time.timeScale = 1;
				}
		         UI-bag = !UI-bag;
		GameObject.SetActive(UI-bag);
			}
		}
