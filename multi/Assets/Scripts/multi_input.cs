using UnityEngine;
using System.Collections;

public class multi_input : controlplayer 
{
    Vector3 last_pos;
    Quaternion last_rot;
    float distance = 0.05f;
    float angle = 0.05f;

	// Use this for initialization
	void Start ()
    {
        last_pos = transform.position;
        last_rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        deplacements();

        if(Vector3.Distance(last_pos, transform.position) > distance)
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
}
