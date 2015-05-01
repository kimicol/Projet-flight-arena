using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class inputs : controlplayer
{

    public KeyCode Avancer = KeyCode.W;
    public KeyCode RotHaut = KeyCode.UpArrow;
    public KeyCode RotBas = KeyCode.DownArrow;
    public KeyCode PivGauche = KeyCode.A;
    public KeyCode PivDroite = KeyCode.D;
    public KeyCode RotGauche = KeyCode.LeftArrow;
    public KeyCode RotDroite = KeyCode.RightArrow;
    public KeyCode feu = KeyCode.Space;

    public UdpClient client;
    string ip;
    private byte[] toSend;
    IPEndPoint serverAddress;

    void Awake()
    {
        ip = PlayerPrefs.GetString("IP");
        serverAddress = new IPEndPoint(IPAddress.Parse(ip), 6000);
        client = new UdpClient(serverAddress);
    }

    // Use this for initialization
    void Start()
    {
        toSend = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
    }
	
	// Update is called once per frame
	void Update () 
    {
        av = Input.GetKey(Avancer);
        RH = Input.GetKey(RotHaut);
        RB = Input.GetKey(RotBas);
        PG = Input.GetKey(PivGauche);
        PD = Input.GetKey(PivDroite);
        RG = Input.GetKey(RotGauche);
        RD = Input.GetKey(RotDroite);
        fire = Input.GetKey(feu);

        if (av)
            toSend[0] = 1;
        else
            toSend[0] = 0;

        if (RH)
            toSend[1] = 1;
        else
            toSend[1] = 0;

        if (RB)
            toSend[2] = 1;
        else
            toSend[2] = 0;

        if (PG)
            toSend[3] = 1;
        else
            toSend[3] = 0;

        if (PD)
            toSend[4] = 1;
        else
            toSend[4] = 0;

        if (RG)
            toSend[5] = 1;
        else
            toSend[5] = 0;

        if (RD)
            toSend[6] = 1;
        else
            toSend[6] = 0;

        if (fire)
            toSend[7] = 1;
        else
            toSend[7] = 0;

        deplacements();
	}
}
