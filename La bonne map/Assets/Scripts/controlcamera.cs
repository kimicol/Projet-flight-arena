using UnityEngine;
using System.Collections;

public class controlcamera : MonoBehaviour
{
    public Transform vaisseau;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(vaisseau != null)
        {
            this.transform.position = vaisseau.transform.position;
            this.transform.Translate(new Vector3(0f, 3f, -9f));
            this.transform.rotation = vaisseau.transform.rotation;
        }
	}
}
