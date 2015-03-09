using UnityEngine;
using System.Collections;

public class controlplayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * 50f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * 50f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 50f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * 50f * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(-Vector3.back * Time.deltaTime * 200f);
        }
	}
}
