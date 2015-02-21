using UnityEngine;
using System.Collections;

public class mainmenu_script : MonoBehaviour 
{
    private int choix_menu = 1;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        switch(choix_menu)
        {
            case 1:
                menu_principal();
                break;
        }
    }

    void menu_principal()
    {
        if(GUI.Button(new Rect(Screen.width/2-200, Screen.height/2, 400, 25), "Commencer"))
        {

        }
    }
}
