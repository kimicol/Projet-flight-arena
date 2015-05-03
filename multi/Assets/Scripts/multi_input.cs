using UnityEngine;
using System.Collections;

public class multi_input : controlplayer 
{
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        deplacements();
	}

    void OnApplicationQuit()
    {
        Network.Disconnect();
    }
}
