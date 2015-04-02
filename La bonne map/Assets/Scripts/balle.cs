using UnityEngine;
using System.Collections;

public class balle : MonoBehaviour {

    public int degat = 1;

	// Use this for initialization
	void Start () 
    {
        DestroyObject(gameObject, 2);
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "spaceship3")
        {
            Debug.Log("test2");
            Destroy(this.gameObject);
        }        
    }
}
