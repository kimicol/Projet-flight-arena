using UnityEngine;
using System.Collections;
using System.Net;

public class controlcamera : MonoBehaviour
{
    public Transform vaisseau;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (vaisseau != null)
        {
            this.transform.rotation = vaisseau.transform.rotation;
            this.transform.position = vaisseau.transform.position;
            this.transform.Translate(new Vector3(0f, 3f, -9f));
        }
    }

    void OnGUI()
    {
        if(Network.peerType == NetworkPeerType.Server)
        {
            string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();

            GUI.Label(new Rect(0, 0, 100, 30), ip);
        }
    }
}
