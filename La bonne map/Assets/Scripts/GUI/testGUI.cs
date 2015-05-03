using UnityEngine;
using System.Collections;

public class testGUI : vie{
    private GUIText life_gui;
	private int life =3;

	// Use this for initialization
	void Start () {
        life_gui = gameObject.GetComponents<GUIText>()[0];
	}
	
	// Update is called once per frame
	void Update () {

	}
     void OnGUI()
    {
		Debug.Log ("test pv :" + life);
        life_gui.text = life.ToString();
    }
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "balle")
		{
			this.life --;
			Debug.Log(pv + " script pv");
			DestroyObject(collision.gameObject);
		}
	}
}
