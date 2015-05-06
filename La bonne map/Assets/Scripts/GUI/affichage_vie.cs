using UnityEngine;
using System.Collections;

public class affichage_vie : MonoBehaviour {

    public vie vie_restante;
    public GUISkin sk;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        GUI.skin = sk;
        GUI.Label(new Rect(Screen.width - 50, Screen.height - 30, 50, 30), "" + vie_restante.current_life);
    }
}
