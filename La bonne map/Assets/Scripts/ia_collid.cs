using UnityEngine;
using System.Collections;

public class ia_collid : MonoBehaviour 
{
    public bool col = false;

	// Use this for initialization
	void Start () 
    {
        this.gameObject.tag = "ia_coll";
	}
	
	// Update is called once per frame
	void Update ()
    {
        //col = false;
	}

    void OnCollisionEnter(Collision colli)
    {
        col = true;
    }

    void OnCollisionExit(Collision colli)
    {
        col = false;
    }

    void OnTriggerEnter(Collider colli)
    {
        col = true;
    }

    void OnTriggerExit(Collider colli)
    {
        col = false;
    }
}
