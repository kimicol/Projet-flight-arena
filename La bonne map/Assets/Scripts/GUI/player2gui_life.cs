using UnityEngine;
using System.Collections;

public class player2gui_life : vie
{
    private GUIText life_gui;
    private GameObject thePlayer;

    // Use this for initialization
    void Start()
    {
        life_gui = gameObject.GetComponents<GUIText>()[0];
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnGUI()
    {
        //Debug.Log ("test pv :" + life);
        thePlayer = GameObject.Find("le him is le player 2");
        vie bob = thePlayer.GetComponent<vie>();
        life_gui.text = bob.VAFANCULO().ToString();
        if (bob.VAFANCULO() < 1)
        {
            life_gui.text = "";
        }
    }
}
