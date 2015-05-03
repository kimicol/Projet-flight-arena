using UnityEngine;
using System.Collections;
using System.Net;

public class mainmenu_script : MonoBehaviour 
{
    private int choix_menu = 1;
    private float volume = 0.5f;
    public GUISkin skin;
    public Texture vaisseau1;
    public Texture vaisseau2;

    //variables multijoueur
    private string ip = "";
    private int port = 6000;
    private int nb_player;

	// Use this for initialization
	void Start () 
    {
        //GUI.skin = skin;
        volume = PlayerPrefs.GetFloat("Volume", volume);

        if(PlayerPrefs.HasKey("Volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", volume);
        }
	}

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.TextArea(new Rect(Screen.width / 3, Screen.height / 5, Screen.width*3/4, Screen.height / 5), "Flight Arena");
        switch(choix_menu)
        {
            case 1:
                menu_principal();
                break;
            case 2:
                menu_options();
                break;
            case 3:
                menu_selection();
                break;
            case 4:
                menu_multi();
                break;
            case 5:
                LaunchServer();
                break;
            case 6:
                rejoindre_multi();
                break;
            case 7:
                menu_serveur();
                break;
        }
    }

    /// <summary>
    /// Le menu principal lorsqu'on arrive sur le jeu>
    /// Redirige vers jouer, multi, options ou quitter
    /// </summary>
    void menu_principal()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 30, 400, 25), "Un joueur"))
        {
            choix_menu = 3;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Multijoueur"))
        {
            choix_menu = 4;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 400, 25), "Options"))
        {
            choix_menu = 2;
            return;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Quitter"))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// Le menu des options
    /// </summary>
    void menu_options()
    {
        //Gestion du son
        volume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 100, 30), volume, 0.0f, 1.0f);
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 30), ("Volume : " + (int)(10*volume)));

        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Retour"))
        {
            choix_menu = 1;
            return;
        }
    }

    void menu_selection()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Retour"))
        {
            choix_menu = 1;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 200, 200), vaisseau1))
        {
            PlayerPrefs.SetInt("vaisseau_joueur", 1);
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 200, 200, 200), vaisseau2))
        {
            PlayerPrefs.SetInt("vaisseau_joueur", 2);
            Application.LoadLevel(1);
        }
    }

    void menu_multi()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 30, 400, 25), "Héberger"))
        {
            choix_menu = 5;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Rejoindre"))
        {
            choix_menu = 6;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Retour"))
        {
            choix_menu = 1;
        }
    }

    void LaunchServer()
    {
        try
        {
            Network.InitializeServer(2, port, !Network.HavePublicAddress());
        }
        catch
        {
            choix_menu = 4;
        }
    }

    void rejoindre_multi()
    {
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 30), "IP de l'hébergeur : ");

        ip = GUI.TextField(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 300, 40), ip, 15);


        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 400, 25), "Rejoindre"))
        {
            Network.Connect(ip, port);
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 150, 400, 25), "Retour"))
            choix_menu = 4;
    }

    void menu_serveur()
    {
        string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();

        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 30), "Nombre de joueurs : " + nb_player);

        if (Network.isServer)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 400, 25), "Jouer"))
            {
                // A TERMINER
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 150, 400, 25), "Retour"))
            {
                Network.Disconnect();
                choix_menu = 4;
            }

            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 30, 400, 30), "IP du serveur : " + ip);
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 150, 400, 25), "Retour"))
            {
                Network.Disconnect();
                choix_menu = 4;
            }
        }
    }

    void OnServerInitialized()
    {
        choix_menu = 7;
        nb_player = 1;
    }

    void OnPlayerConnected()
    {
        nb_player++;
    }

    void OnPlayerDisconnected()
    {
        nb_player--;
    }
}
