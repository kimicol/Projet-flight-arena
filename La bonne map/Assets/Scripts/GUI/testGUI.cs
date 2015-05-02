using UnityEngine;
using System.Collections;

public class testGUI : MonoBehaviour {
    private GUIText life_gui;
    public int nb_pv; // il faudrait que cette valeur soit egale au nombre de pv du vaisseau (du script vie.cs par ex ) pour que j'execute ensuite le OnGUI. gl hf


	// Use this for initialization
	void Start () {
        life_gui = gameObject.GetComponents<GUIText>()[0];
	}
	
	// Update is called once per frame
	void Update () {

	}
    private void OnGUI()
    {
        //life_gui.text = nb_pv.ToString();
    }
}
