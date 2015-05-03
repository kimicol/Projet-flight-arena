using UnityEngine;
using System.Collections;

public class testGUI : vie{
    private GUIText life_gui;

	// Use this for initialization
	void Start () {
        life_gui = gameObject.GetComponents<GUIText>()[0];
	}
	
	// Update is called once per frame
	void Update () {

	}
     void OnGUI()
    {
		//Debug.Log ("test pv :" + life);
        GameObject thePlayer = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI");
        vie john = thePlayer.GetComponent<vie>();
        Debug.Log(john.VAFANCULO().ToString());
        life_gui.text = john.VAFANCULO().ToString();
    }
}
