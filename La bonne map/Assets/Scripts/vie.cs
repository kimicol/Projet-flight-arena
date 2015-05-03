using UnityEngine;
using System.Collections;

public class vie : MonoBehaviour {

    public int pv = 5;
    private bool killed;

    public Transform depart;
    public GUISkin skin;
    //public Animation anim;

    void Start()
    {
        /*anim = gameObject.GetComponent<Animation>();
        if(anim == null)
        {
            Debug.Log("test");
        }*/
        killed = false;
    }

    void Update()
    {
        if (pv <= 0 )//&& !anim.isPlaying)
        {
            //anim.Play();
            killed = true;
            DestroyObject(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            this.pv -= 1;
            //Debug.Log(pv + " script pv");
            DestroyObject(collision.gameObject);
        }
    }

    void OnGUI()
    {
		/*
        if(skin != null)
            skin.label.fontSize = 70;
        GUI.skin = skin;
        if(killed)
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Perdu");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Rejouer"))
            {
                DestroyObject(this.gameObject);
                Instantiate(this.gameObject, depart.position, depart.rotation);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Retour au menu"))
                Application.LoadLevel(0);
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Quitter le jeu"))
                Application.Quit();
                */
        //}
    }
}
