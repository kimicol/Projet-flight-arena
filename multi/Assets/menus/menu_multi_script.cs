using UnityEngine;
using System.Collections;

public class menu_multi_script : MonoBehaviour 
{
    private int choix_menu = 1;
    private string ip = "";
    private int port = 6000;

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
                menu_multi();
                break;
            case 2:
                LaunchServer();
                break;
            case 3:
                rejoindre_multi();
                break;
        }
    }

    void menu_multi()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 30, 400, 25), "Héberger"))
        {
            choix_menu = 2;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Rejoindre"))
        {
            choix_menu = 3;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Retour"))
        {
            Application.LoadLevel(0);
        }
    }

    void LaunchServer()
    {
        Network.InitializeServer(2, port, !Network.HavePublicAddress());
    }

    void rejoindre_multi()
    {       
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 30), "IP de l'hébergeur : ");
        
        ip = GUI.TextField(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 100, 40), ip, 10);
    }
}
