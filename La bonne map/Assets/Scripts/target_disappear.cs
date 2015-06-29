using UnityEngine;
using System.Collections;

public class target_disappear : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter(Collider Collision)
	{
		DestroyObject(this.gameObject);
	}
}
