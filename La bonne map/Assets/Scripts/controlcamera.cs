using UnityEngine;
using System.Collections;

public class controlcamera : MonoBehaviour
{
    public Transform vaisseau;
    public vie vie_restante;
    public GUISkin sk;

	// Use this for initialization
	void Start ()
    {
        vie_restante = vaisseau.GetComponent<vie>();
	}

    void OnGUI()
    {
        GUI.skin = sk;
        /*
        Debug.Log(camera.rect.y);
        if (this.camera.rect.yMax == 1)
        {
            GUI.Label(new Rect(Screen.width - 50, (0.5f * Screen.height) - 30, 50, 30), "" + vie_restante.current_life);
        }
        else
        {
            GUI.Label(new Rect(Screen.width - 50, (Screen.height) - 30, 50, 30), "" + vie_restante.current_life);
        }
        */
        GUI.Label(new Rect(Screen.width - 50, (camera.rect.y + 0.5f) * Screen.height - 30, 50, 30), "" + vie_restante.current_life);
    }
	
	// Update is called once per frame
    void Update()
    {
        if (vaisseau != null)
        {
            this.transform.position = vaisseau.transform.position;
            this.transform.Translate(new Vector3(0f, 3f, -9f));
            this.transform.rotation = vaisseau.transform.rotation;
        }
    }
}
