using UnityEngine;
using System.Collections;

public class flamme_script : MonoBehaviour {
    private GameObject otherObject;
    private KeyCode AvanC;
    private bool av;
	// Use this for initialization
    void Start()
    {
        otherObject = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI");
        inputs bob = otherObject.GetComponent<inputs>();
        AvanC = bob.Avancer;
    }
	
	// Update is called once per frame
	void Update ()
    {
        av = Input.GetKey(AvanC);
        if (!av)
        {
            this.particleSystem.enableEmission = false;
        }
        else
        {
            this.particleSystem.enableEmission = true;
        }
	}
}
