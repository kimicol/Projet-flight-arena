using UnityEngine;
using System.Collections;

public class flammeplayer2 : MonoBehaviour {
    private GameObject otherObject;
    private KeyCode AvanC;
    private bool av;
    // Use this for initialization
    void Start()
    {
        otherObject = GameObject.Find("le him is le player 2");
        inputs bob = otherObject.GetComponent<inputs>();
        AvanC = KeyCode.UpArrow;
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
