using UnityEngine;
using System.Collections;

public class balle : MonoBehaviour {

    public int degat = 1;

	// Use this for initialization
	void Start () 
    {
        this.gameObject.tag = "balle";
        DestroyObject(gameObject, 2);
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
	}
}
