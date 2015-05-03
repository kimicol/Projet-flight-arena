using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class multi_input : controlplayer 
{
    public UdpClient client;
    private string ip;
    private byte[] toSend;
    private IPEndPoint serverAddress;

    void Awake()
    {
        ip = PlayerPrefs.GetString("IP");
        serverAddress = new IPEndPoint(IPAddress.Parse(ip), 6000);
        client = new UdpClient(serverAddress);
    }

	// Use this for initialization
	void Start ()
    {
        toSend = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0};
	}
	
	// Update is called once per frame
	void Update () 
    {
        toSend = client.Receive(ref serverAddress);

        av = toSend[0] == 1;
        RH = toSend[1] == 1;
        RB = toSend[2] == 1;
        PG = toSend[3] == 1;
        PD = toSend[4] == 1;
        RG = toSend[5] == 1;
        RD = toSend[6] == 1;
        fire = toSend[7] == 1; ;

        deplacements();
	}

    void OnApplicationQuit()
    {
        client.Close();
    }
}
