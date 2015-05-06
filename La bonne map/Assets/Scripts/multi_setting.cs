using UnityEngine;
using System.Collections;

public class multi_setting : MonoBehaviour 
{
    private int menu;
    private string ip = "";
    private int port = 25000;
    private int choix_vaisseau = 2;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    private GameObject vaisseau;
    private bool b = true;

	// Use this for initialization
	void Start () 
    {
        menu = 1;
        choix_vaisseau = PlayerPrefs.GetInt("player", choix_vaisseau);

        if (PlayerPrefs.HasKey("player"))
        {
            choix_vaisseau = PlayerPrefs.GetInt("player", choix_vaisseau);
        }
        else
        {
            PlayerPrefs.SetInt("player", choix_vaisseau);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnGUI()
    {
        switch(menu)
        {
            case 1:
                select_connexion();
                break;
            case 2:
                menu_rejoindre();
                break;
        }
    }

    void select_connexion()
    {
        if (GUI.Button(new Rect(Screen.width/2, Screen.height/2, 300, 30), "Héberger"))
        {
            Network.InitializeServer(4, 25000, true);
            if (Network.peerType == NetworkPeerType.Server)
            {
                menu = 3;
                nouveau_joueur();
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 30, 300, 30), "Rejoindre"))
        {
            menu = 2;
        }
    }

    void menu_rejoindre()
    {
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 30), "IP de l'hébergeur : ");

        ip = GUI.TextField(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 300, 40), ip, 15);


        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 400, 25), "Rejoindre"))
        {
            Network.Connect(ip, port);
            if (Network.peerType == NetworkPeerType.Client)
            {
                menu = 3;
                //nouveau_joueur();
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 150, 400, 25), "Retour"))
            menu = 1;
    }

    void OnServerInitialized()
    {
        nouveau_joueur();
    }

    void OnConnectedToServer()
    {
        menu = 3;
        nouveau_joueur();
    }

    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        Network.Destroy(vaisseau);
    }

    void nouveau_joueur()
    {
        Vector3 pos = Vector3.zero;

        System.Random rnd = new System.Random();
        pos.Set(rnd.Next(-100, 100), rnd.Next(70), rnd.Next(-100, 100));
        //Debug.Log(Network.peerType);
        switch(choix_vaisseau)
        {
            case 1:
                vaisseau = (GameObject)Network.Instantiate(prefab1, pos, Quaternion.AngleAxis(0, Vector3.left), 0);
                break;
            case 2:
                vaisseau = (GameObject)Network.Instantiate(prefab2, pos, Quaternion.AngleAxis(0, Vector3.left), 0);
                break;
            case 3:
                vaisseau = (GameObject)Network.Instantiate(prefab3, pos, Quaternion.AngleAxis(0, Vector3.left), 0);
                break;
        }

        this.camera.enabled = false;
        //vaisseau.camera.enabled = true;
    }
}
