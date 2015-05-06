using UnityEngine;
using System.Collections;
using System.Net;

public class controlcameramulti : MonoBehaviour
{
    public Transform vaisseau;
    public vie vie_restante;
    public GUISkin sk;

    void Awake()
    {
        camera.enabled = networkView.isMine;
        vie_restante = vaisseau.GetComponents<vie>()[0];
    }

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
    void FixedUpdate()
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

        GUI.skin = sk;
        GUI.Label(new Rect(Screen.width - 50, Screen.height - 30, 50, 30), "" + vie_restante.current_life);

    }
}
