using UnityEngine;
using System.Collections;

public class testGUI : vie
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
        try
        {
            thePlayer = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI");
        }
        catch
        {
            thePlayer = GameObject.Find("vaisseau1");
        }      
        vie bob = thePlayer.GetComponent<vie>();
        life_gui.text = bob.VAFANCULO().ToString();
        if (bob.VAFANCULO() < 1)
        {
            life_gui.text = "";
        }
    }
}
