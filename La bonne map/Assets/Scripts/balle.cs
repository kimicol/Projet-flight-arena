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
        string temp = name;
        temp = temp.Remove(temp.Length - 7);
        name = temp;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 400);
	}

}
