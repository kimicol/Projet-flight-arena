using UnityEngine;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;

public class menu_multi_script : MonoBehaviour 
{
    private int choix_menu = 1;
    public UdpClient client;
    private string ip = "";

	// Use this for initialization
	void Start () 
    {
        ip = PlayerPrefs.GetString("IP");

        if (PlayerPrefs.HasKey("IP"))
        {
            ip = PlayerPrefs.GetString("IP");
        }
        else
        {
            PlayerPrefs.SetString("IP", ip);
        }
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
                heberger_multi();
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

    void heberger_multi()
    {
        IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());
        
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 50), "Votre IP : " + ip.AddressList[0].ToString());
    }

    void rejoindre_multi()
    {       
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 30), "IP de l'hébergeur : ");
        
        ip = GUI.TextField(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 100, 40), ip, 10);

        try
        {
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ip), 6000);
            client = new UdpClient(serverAddress);
            //client.Connect(serverAddress);
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 100, 30), "IP valide");
            client.Close();

            if(GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Jouer"))
            {
                Application.LoadLevel(1);
            }
        }
        catch 
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 100, 30), "IP invalide");
        }
    }
}
