using UnityEngine;
using System.Collections;

public class ia_collid : MonoBehaviour {

    public bool col = false;

	// Use this for initialization
	void Start () 
    {
	
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
}
