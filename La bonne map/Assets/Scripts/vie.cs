using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class vie : MonoBehaviour
{

    public int pv = 5;
    public int current_life;
    private bool killed;
    private int frag_limite = 3;
    public bool respawn = true;
    private Vector3 respawn_position;
    public GameObject winner;
    private GameObject thePlayer;
    private GameObject cube0;
    public AudioClip hitmarker;
    public GUIText thewinnergui;
    public Transform depart;
    public GUISkin skin;
    public Animation anim;

    void Start()
    {
        //Cube_MeshPart0
        /*anim = gameObject.GetComponent<Animation>();
        if(anim == null)
        {
            Debug.Log("test");
        }*/
        current_life = pv;
        killed = false;
    }

    void Update()
    {
        if (current_life <= 0)//&& !anim.isPlaying)
        {
            //anim.Play();
            if (!respawn)
            {
                DestroyObject(this.gameObject);
            }
            else
            {
                if (frag_limite > 1)
                {

                    System.Random rnd = new System.Random();
                  //  inputs bob = this.gameObject.GetComponent<inputs>();
                  //  bob.enabled = false;
                    /*cube0 = GameObject.FindGameObjectWithTag("Cube_MeshPart0");
                    cube0.renderer.enabled = false;
                    cube0 = GameObject.FindGameObjectWithTag("Cube_MeshPart1");
                    cube0.renderer.enabled = false;*/
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.left);
                    respawn_position.Set(rnd.Next(-120, 120), rnd.Next(80), rnd.Next(-120, 120));
                    transform.position = respawn_position;
                    current_life = pv;
            /*        cube0 = GameObject.FindGameObjectWithTag("Cube_MeshPart0");
                    cube0.renderer.enabled = true;
                    cube0 = GameObject.FindGameObjectWithTag("Cube_MeshPart1");
                    cube0.renderer.enabled = true;
                    bob.enabled = true;*/
                    frag_limite--;
                }
                else
                {
                    frag_limite--;
                    DestroyObject(this.gameObject);
                    gameover();
                    killed = true;
                }
            }
            //this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            this.current_life -= 1;
            audio.PlayOneShot(hitmarker);
            //Debug.Log(current_life + " script pv");
            // DestroyObject(collision.gameObject);
        }
    }

    void OnGUI()
    {

        if (skin != null)
            skin.label.fontSize = 70;
        GUI.skin = skin;
        if (killed)
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

        }
    }
    public int VAFANCULO()
    {
        return this.current_life;
    }
    public void gameover ()
    {
        GameObject.Find("gameoverCAM").camera.depth = 2;
        winner = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI");
        vie bob = winner.GetComponent<vie>();
        thePlayer = GameObject.Find("GameWinner_GUI");
        if (bob.frag_limite<1)
        {
            thePlayer.guiText.text = ("PLAYER 2 WIN");
        }
        else
        {
            thePlayer.guiText.text = ("PLAYER 1 WIN");
        }
        
    }
}
