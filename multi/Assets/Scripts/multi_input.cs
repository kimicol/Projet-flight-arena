using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class multi_input : controlplayer 
{
    public UdpClient client;
    private bool[] inputs;

    public KeyCode Avancer = KeyCode.W;
    public KeyCode RotHaut = KeyCode.UpArrow;
    public KeyCode RotBas = KeyCode.DownArrow;
    public KeyCode PivGauche = KeyCode.A;
    public KeyCode PivDroite = KeyCode.D;
    public KeyCode RotGauche = KeyCode.LeftArrow;
    public KeyCode RotDroite = KeyCode.RightArrow;
    public KeyCode feu = KeyCode.Space;

    void Awake()
    {
        client = new UdpClient();
    }

	// Use this for initialization
	void Start ()
    {
        inputs = new bool[] { false, false, false, false, false, false, false, false };
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}
}
