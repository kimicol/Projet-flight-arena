using UnityEngine;
using System.Collections;

public class selfDestruction : MonoBehaviour 
{
    public Transform pos;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
