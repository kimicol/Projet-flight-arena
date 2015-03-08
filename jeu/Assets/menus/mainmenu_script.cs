using UnityEngine;
using System.Collections;

public class mainmenu_script : MonoBehaviour 
{
    private int choix_menu = 1;
    private int volume = 5;

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
            case 2:
                menu_options();
                break;
        }
    }

    void menu_principal()
    {
        if(GUI.Button(new Rect(Screen.width/2-200, Screen.height/2 - 60, 400, 25), "Un joueur"))
        {
            Application.LoadLevel("try");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 30, 400, 25), "Multijoueur"))
        {
            // A MODIFIER
            Application.Quit();
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Options"))
        {
            choix_menu = 2;
            return;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 400, 25), "Quitter"))
        {
            Application.Quit();
        }
    }

    void menu_options()
    {
        volume = (int)GUI.HorizontalSlider(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 100, 30), (float)volume, 0.0f, 10.0f);
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 80, 100, 30), ("Volume : " + volume));

        Camera.main.audio.volume = volume;

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Retour"))
        {
            choix_menu = 1;
            return;
        }
    }
}
