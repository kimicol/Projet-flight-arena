using UnityEngine;
using System.Collections;

public class controlcamera : MonoBehaviour
{
    public Transform vaisseau;
    private int type_vaisseau;
    public vie vie_restante;
    public GUISkin sk;

	// Use this for initialization
	void Start ()
    {
        vie_restante = vaisseau.GetComponents<vie>()[0];
        type_vaisseau = vie_restante.type_vaisseau;
	}

    void OnGUI()
    { /*
        GUI.skin = sk;
        GUI.Label(new Rect(Screen.width - 50, Screen.height - 30, 50, 30), "" + vie_restante.current_life); */
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        if (vaisseau != null)
        {
            switch()
            {

            }
            this.transform.position = vaisseau.transform.position;
            this.transform.Translate(new Vector3(0f, 3f, -9f));
            this.transform.rotation = vaisseau.transform.rotation;
        }
    }
}
