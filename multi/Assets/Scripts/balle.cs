using UnityEngine;
using System.Collections;

public class balle : MonoBehaviour {

    public int degat = 1;
    private Vector3 last_pos;
    private float distance = 0.05f;

	// Use this for initialization
	void Start () 
    {
        this.gameObject.tag = "balle";
        DestroyObject(gameObject, 2);
        audio.Play();
        last_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 400);

        if (Vector3.Distance(last_pos, transform.position) > distance)
        {
            last_pos = transform.position;
            networkView.RPC("SetPos", RPCMode.Others, transform.position);
        }
	}

    [RPC]
    void SetPos(Vector3 newPos)
    {
        transform.position = newPos;
    }
}
