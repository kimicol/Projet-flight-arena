using UnityEngine;
using System.Collections;

public class multi_input : controlplayer 
{
    Vector3 last_pos;
    Quaternion last_rot;
    float distance = 0.01f;
    float angle = 0.01f;

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
        //enabled = networkView.isMine;
        rigidbody.isKinematic = !networkView.isMine;
    }

	// Use this for initialization
	void Start ()
    {
        last_pos = transform.position;
        last_rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (networkView.isMine)
        {
            av = Input.GetKey(Avancer);
            RH = Input.GetKey(RotHaut);
            RB = Input.GetKey(RotBas);
            PG = Input.GetKey(PivGauche);
            PD = Input.GetKey(PivDroite);
            RG = Input.GetKey(RotGauche);
            RD = Input.GetKey(RotDroite);
            fire = Input.GetKey(feu);

            deplacements();

            if (Vector3.Distance(last_pos, transform.position) > distance)
            {
                last_pos = transform.position;
                networkView.RPC("SetPos", RPCMode.Others, transform.position);
            }

            if (Quaternion.Angle(last_rot, transform.rotation) > angle)
            {
                last_rot = transform.rotation;
                networkView.RPC("SetRot", RPCMode.Others, transform.rotation);
            }
        }
	}

    void OnApplicationQuit()
    {
        Network.Disconnect();
    }

    [RPC]
    void SetPos(Vector3 newPos)
    {
        transform.position = newPos;
    }

    [RPC]
    void SetRot(Quaternion newRot)
    {
        transform.rotation = newRot;
    }

    void OnSerializeNetworkView(BitStream flux, NetworkMessageInfo info)
    {
        if (flux.isWriting)
        {
            Vector3 pos = transform.position;
            flux.Serialize(ref pos);
        }
        else
        {
            Vector3 pos = Vector3.zero;
            flux.Serialize(ref pos); //"Decode" it and receive it
            transform.position = pos;
        }
    }
}
