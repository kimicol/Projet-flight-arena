using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class vie : MonoBehaviour
{
    public int pv = 3;
    public int current_life;
    private bool killed;
    private bool affiche = false;
    public int frag_limite = 5;
    public bool respawn = true;
    public bool ok = false;
    private Vector3 respawn_position;
    public GameObject winner;
    private GameObject thePlayer;
    private GameObject crosshair;
    private MeshRenderer cube0;
    public AudioClip hitmarker;
    public AudioClip endgame_sound;
    public Transform depart;
    private Transform selected;
    public GUISkin skin;
    public Animation anim;

    void Start()
    {
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
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.left);
                    inputs bob = this.gameObject.GetComponent<inputs>();
                    bob.enabled = false;
                    cube0 = this.gameObject.GetComponentsInChildren<MeshRenderer>()[0];
                    cube0.renderer.enabled = false;
                    cube0 = this.gameObject.GetComponentsInChildren<MeshRenderer>()[1];
                    cube0.renderer.enabled = false;
                    crosshair = GameObject.Find("crosshair");
                    crosshair.guiTexture.enabled = false;
                    StartCoroutine(W8M8());
                    if (!ok)
                    {
                        return;
                    }
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.left);
                    respawn_position.Set(rnd.Next(-120, 120), rnd.Next(80), rnd.Next(-120, 120));
                    transform.position = respawn_position;
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.left);
                    current_life = pv;
                    cube0 = this.gameObject.GetComponentsInChildren<MeshRenderer>()[0];
                    cube0.renderer.enabled = true;
                    cube0 = this.gameObject.GetComponentsInChildren<MeshRenderer>()[1];
                    cube0.renderer.enabled = true;
                    crosshair.guiTexture.enabled = true;
                    bob.enabled = true;
                    frag_limite--;
                    ok = false;
                }
                else
                {
                    frag_limite--;
                    DestroyObject(this.gameObject);
                    try
                    {
                        GameObject steveGameObject = GameObject.Find("player 1 cam");
                        AudioSource shut = steveGameObject.GetComponent<AudioSource>();
                        shut.audio.clip = endgame_sound;
                        shut.PlayOneShot(endgame_sound);
                    }
                    catch
                    { Debug.Log("hue"); }
                    Debug.Log("son");
                    gameover();
                    killed = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            this.current_life -= 1;
            audio.PlayOneShot(hitmarker);
            //Debug.Log(current_life + " script pv");
        }
        ok = false;
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
        thePlayer = GameObject.Find("gameoverGUI");
        thePlayer.guiText.text = ("GAME OVER");
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
        StartCoroutine(postgameover());
        while (!affiche)
        {
            return;
        }
    }
    public void gameover(string vainc)
    {
        GameObject.Find("gameoverCAM").camera.depth = 2;
        thePlayer = GameObject.Find("gameoverGUI");
        thePlayer.guiText.text = ("GAME OVER");
        GameObject.Find("GameWinner_GUI").guiText.text = (vainc);
        StartCoroutine(postgameover());
        while (!affiche)
        {
            return;
        }

    }
    IEnumerator W8M8()
    {
        yield return new WaitForSeconds(2.0f);
        ok = true;
    }
    IEnumerator postgameover()
    {
        yield return new WaitForSeconds(5.0f);
        affiche = true;
        Application.LoadLevel(0);
    }
}
