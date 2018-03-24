using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {
    
    public Canvas InGameMenu;
    private bool menuEnabled = false;

    // Use this for initialization
    void Start()
    {
        InGameMenu = InGameMenu.GetComponent<Canvas>();
        menuEnabled = false;
        InGameMenu.enabled = menuEnabled;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            menuEnabled = !menuEnabled;
            InGameMenu.enabled = menuEnabled;
        }
    }
}
