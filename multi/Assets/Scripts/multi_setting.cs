﻿using UnityEngine;
using System.Collections;

public class multi_setting : MonoBehaviour 
{
    private int menu;
    private string ip = "";
    private int port = 25000;
    public Transform prefab;

	// Use this for initialization
	void Start () 
    {
        menu = 1;
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
            Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
            if(Network.peerType == NetworkPeerType.Server)
                menu = 3;
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
            if(Network.peerType == NetworkPeerType.Client)
            {
                menu = 3;
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
        nouveau_joueur();
    }

    void nouveau_joueur()
    {
        //A TERMINER
        Network.Instantiate(prefab, , ,0);
    }
}