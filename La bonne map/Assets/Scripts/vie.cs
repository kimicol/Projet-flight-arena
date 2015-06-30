using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class vie : MonoBehaviour
{
    #region attributs
    public int pv = 3;
    public int current_life;
    private bool killed;
    public string name;
    public bool bool_killfeed;
    private bool test_feed = false;
    public string tueur;
    public string couleur;
    private bool affiche = false;
    public int frag_limite = 5;
    public bool respawn = true;
    public bool ok = false;
    private Vector3 respawn_position;
    public GameObject winner;
    public GameObject sphere;
    private GameObject thePlayer;
    private GameObject crosshair;
    
    public AudioClip hitmarker;
    public AudioClip endgame_sound;
    public Transform depart;
    private Transform selected;
    public GUISkin skin;
    public Animation anim;
    public ParticleSystem explosion;

    public Camera global_cam;
    private bool can_explode = true;

    public GameObject[] all_spaceships;
    private vie[] all_life;

    private int mode_jeu = 1;
    #endregion

    void Awake()
    {
        mode_jeu = PlayerPrefs.GetInt("mode_jeu", mode_jeu);
        if (PlayerPrefs.HasKey("mode_jeu"))
        {
            mode_jeu = PlayerPrefs.GetInt("mode_jeu", mode_jeu);
        }
        else
        {
            PlayerPrefs.SetInt("mode_jeu", mode_jeu);
        }

        if(mode_jeu == 3)
        {
            frag_limite = 9999;
        }
    }

    void Start()
    {
        /*anim = gameObject.GetComponent<Animation>();
        if(anim == null)
        {
            Debug.Log("test");
        }*/
        current_life = pv;
        killed = false;

        all_life = new vie[all_spaceships.Length];
        for (int i = 0; i < all_spaceships.Length; i++)
        {
            if (all_spaceships[i] != null)
            {
                all_life[i] = all_spaceships[i].GetComponent<vie>();
                if (all_life[i] == null)
                {
                    all_life[i] = all_spaceships[i].GetComponentInChildren<vie>();
                }
            }
        }
    }

    void Update()
    {
        if (mode_jeu == 3)
        {
            for (int i = 0; i < all_spaceships.Length; i++)
            {
                if (all_spaceships[i] != null)
                {
                    all_life[i] = all_spaceships[i].GetComponent<vie>();
                    if (all_life[i] == null)
                    {
                        all_life[i] = all_spaceships[i].GetComponentInChildren<vie>();
                    }
                }
            }
        }

        //Debug.Log(bool_killfeed);
        if (current_life <= 0)//&& !anim.isPlaying)
        {
            GameObject explode;

            if (can_explode)
            {
                if(mode_jeu == 3)
                {
                    explode = Network.Instantiate(explosion, this.transform.position, this.transform.rotation, 0) as GameObject;
                }
                else
                    explode = Instantiate(explosion, this.transform.position, this.transform.rotation) as GameObject;

                can_explode = false;
            }

            //anim.Play();
            if (!respawn)
            {
                DestroyObject(this.gameObject);
            }
            else
            {
                if (frag_limite > 1)
                {
                    MeshRenderer[] cube0;

                    sphere.renderer.enabled = false;
                    System.Random rnd = new System.Random();
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.left);
                    //controlplayer bob = this.gameObject.GetComponent<controlplayer>();
                    //bob.enabled = false;

                    cube0 = this.gameObject.GetComponentsInChildren<MeshRenderer>();
                    for (int i = 0; i < cube0.Length; i++)
                    {
                        cube0[i].enabled = false;
                    }

                    try
                    {
                        crosshair = GameObject.Find("crosshair");
                        crosshair.guiTexture.enabled = false;
                    }
                    catch { }
                    StartCoroutine(W8M8());
                    if (!ok)
                    {
                        return;
                    }
                    //Debug.Log("hue");
                    test_feed = false;
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.left);
                    respawn_position.Set(rnd.Next(-120, 120), rnd.Next(80), rnd.Next(-120, 120));
                    transform.position = respawn_position;
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.left);
                    current_life = pv;

                    for (int i = 0; i < cube0.Length; i++)
                    {
                        cube0[i].renderer.enabled = true;
                    }
                    
                    crosshair.guiTexture.enabled = true;
                    //bob.enabled = true;
                    frag_limite--;
                    ok = false;
                    sphere.renderer.enabled = true;
                }
                else
                {
                    frag_limite--;
                    DestroyObject(this.gameObject);
                    try
                    {
                        Camera steveGameObject = this.GetComponentInParent<Camera>();
                        AudioSource shut = steveGameObject.GetComponent<AudioSource>();
                        shut.audio.clip = endgame_sound;
                        shut.PlayOneShot(endgame_sound);
                    }
                    catch
                    { /*Debug.Log("hu2");*/ }
                    //Debug.Log("son");
                    gameover();
                    killed = true;
                }
            }
        }
        else
        {
            can_explode = true;
        }
    }

    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            this.tueur = collision.name;
            this.current_life -= 1;
            if (current_life <= 0)
            {
                if (!test_feed)
                {
                    bool_killfeed = true;
                    test_feed = true;
                }
                
            }
            //Debug.Log(current_life + " <- current_life + bool -> " + bool_killfeed);
            audio.PlayOneShot(hitmarker);
        }
        ok = false;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "ia_coll")
        {
            this.current_life -= 2;
            ok = false;
            if (current_life <= 0)
            {
                if (!test_feed)
                {
                    bool_killfeed = true;
                    test_feed = true;
                }
            }
            this.tueur = "Bad piloting";
        }

        if (collision.gameObject.tag == "balle")
        {
            this.tueur = collision.gameObject.name;
            this.current_life -= 1;
            if (current_life <= 0)
            {
                bool_killfeed = true;
            }
            //Debug.Log(current_life + " <- current_life + bool -> " + bool_killfeed);
            audio.PlayOneShot(hitmarker);
        }
        ok = false;
    }

    void OnGUI()
    {

        if (skin != null)
        {
            skin.label.fontSize = 70;
            GUI.skin = skin;
        }
        if (killed)
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Perdu");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Replay"))
            {
                DestroyObject(this.gameObject);
                Instantiate(this.gameObject, depart.position, depart.rotation);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Back to"))
                Application.LoadLevel(0);
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Close the game"))
                Application.Quit();
        }
    }

    public int VAFANCULO()
    {
        return this.current_life;
    }

    public void gameover ()
    {
        int alive = 0;
        int count = -1;
        for (int i = 0; i < all_life.Length; i++)
        {
            if(all_life[i] != null && all_life[i].current_life > 0)
            {
                alive++;
                count = i;
            }
        }

        if(alive == 1)
        {
            thePlayer = GameObject.Find("gameoverGUI");
            thePlayer.guiText.text = ("GAME OVER");
            GameObject.Find("GameWinner_GUI").guiText.text = (all_life[count].name + " WIN");
            StartCoroutine(postgameover());
            while (!affiche)
            {
                return;
            }
        }
        else if(alive < 1)
        {
            thePlayer = GameObject.Find("gameoverGUI");
            thePlayer.guiText.text = ("GAME OVER");
            GameObject.Find("GameWinner_GUI").guiText.text = ("GAME DRAW");
            StartCoroutine(postgameover());
            while (!affiche)
            {
                return;
            }
        }
    }

    public void gameover(string vainc)
    {
        global_cam.depth = 2;
        //GameObject.Find("gameoverCAM").camera.depth = 2;
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
