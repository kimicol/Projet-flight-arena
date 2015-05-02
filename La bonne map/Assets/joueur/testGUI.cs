using UnityEngine;
using System.Collections;

public class testGUI : MonoBehaviour {
    private GUIText life_gui;
    private int nb_pv;
    private Vector2 position;

	// Use this for initialization
	void Start () {
        life_gui = gameObject.GetComponents<GUIText>()[0];
	}
	
	// Update is called once per frame
	void Update () {
        OnGui();
	}
    private void OnGui()
    {
        life_gui.text = nb_pv.ToString();
    }
}
