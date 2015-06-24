using UnityEngine;
using System.Collections;

public class flamme_script : MonoBehaviour {
    private GameObject otherObject;
    //private KeyCode AvanC;
    vie VI;
	// Use this for initialization
    void Start()
    {
        otherObject = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI");
       // inputs inpu = otherObject.GetComponent<inputs>();
        VI = otherObject.GetComponent<vie>();
       // AvanC = inpu.used_keys[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (VI.current_life > 0)
        {
            ;
            if (Input.GetKey(KeyCode.W))
            {
                 this.particleSystem.enableEmission = true;       
            }
            else
            {
                this.particleSystem.enableEmission = false;
            }
        }
        else
        {
            this.particleSystem.enableEmission = false;
        }
        Debug.Log(particleSystem.enableEmission);
	}
}
