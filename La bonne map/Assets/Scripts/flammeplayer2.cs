using UnityEngine;
using System.Collections;

public class flammeplayer2 : MonoBehaviour {
    private GameObject otherObject;
    private KeyCode AvanC;
    private bool av;
    private bool alter;
    // Use this for initialization
    void Start()
    {
        otherObject = GameObject.Find("le him is le player 2");
        inputs bob = otherObject.GetComponent<inputs>();
        AvanC = bob.Avancer;
    }

    // Update is called once per frame
    void Update()
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
