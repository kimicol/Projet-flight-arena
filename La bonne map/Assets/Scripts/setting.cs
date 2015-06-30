using UnityEngine;
using System.Collections;

public class setting : MonoBehaviour
{
    #region attributs
    //Mettre l'image en bonne qualité
    private int qualite_image = 0;
    private int aliasing = 0;
    private int anisotropic;

    //Mettre les parametres de son
    private float volume = 0.5f;
    private int son = 0;

    //Pour le joueur
    public GameObject vaisseau1;
    public GameObject vaisseau2;
    public GameObject vaisseau3;
    private int choix = 1;
    private Random rnd;

    //Pour les IA
    public GameObject IA1;
    public GameObject IA2;
    public GameObject IA3;
    int nb_joueur = 2;
    public GameObject[] all_spaceships;

    //Pour le multi
    public GameObject vaisseau1_multi;
    public GameObject vaisseau2_multi;
    public GameObject vaisseau3_multi;
    private int menu;
    private string ip = "";
    private int port = 25000;
    public GUISkin skin;
    private GameObject vaisseau_multi;

    bool b = true;

    private int mode_jeu = 1;
    private string name = "";
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
    }

    // Use this for initialization
	void Start ()
    {
        #region PlayerPrefs Options
        volume = PlayerPrefs.GetFloat("Volume", volume);
        if (PlayerPrefs.HasKey("Volume"))
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        else
            PlayerPrefs.SetFloat("Volume", volume);

        son = PlayerPrefs.GetInt("son", son);
        if (PlayerPrefs.HasKey("son"))
        {
            son = PlayerPrefs.GetInt("son", son);
            switch (son)
            {
                case 0:
                    AudioSettings.speakerMode = AudioSpeakerMode.Mono;
                    break;
                case 1:
                    AudioSettings.speakerMode = AudioSpeakerMode.Stereo;
                    break;
                case 2:
                    AudioSettings.speakerMode = AudioSpeakerMode.Quad;
                    break;
                case 3:
                    AudioSettings.speakerMode = AudioSpeakerMode.Surround;
                    break;
                case 4:
                    AudioSettings.speakerMode = AudioSpeakerMode.Mode5point1;
                    break;
                case 5:
                    AudioSettings.speakerMode = AudioSpeakerMode.Mode7point1;
                    break;
            }
        }
        else
            PlayerPrefs.SetInt("son", son);

        qualite_image = PlayerPrefs.GetInt("qualite_image", qualite_image);
        if (PlayerPrefs.HasKey("qualite_image"))
        {
            qualite_image = PlayerPrefs.GetInt("qualite_image", qualite_image);
            QualitySettings.SetQualityLevel(qualite_image);
        }
        else
            PlayerPrefs.SetInt("qualite_image", qualite_image);

        aliasing = PlayerPrefs.GetInt("aliasing", aliasing);
        if (PlayerPrefs.HasKey("aliasing"))
        {
            aliasing = PlayerPrefs.GetInt("aliasing", aliasing);
            switch (aliasing)
            {
                case 0:
                    QualitySettings.antiAliasing = 0;
                    break;
                case 1:
                    QualitySettings.antiAliasing = 2;
                    break;
                case 2:
                    QualitySettings.antiAliasing = 4;
                    break;
                case 3:
                    QualitySettings.antiAliasing = 8;
                    break;
            }
        }
        else
            PlayerPrefs.SetInt("aliasing", aliasing);

        anisotropic = PlayerPrefs.GetInt("anisotropic", anisotropic);
        if (PlayerPrefs.HasKey("anisotropic"))
        {
            qualite_image = PlayerPrefs.GetInt("anisotropic", anisotropic);
            switch (anisotropic)
            {
                case 0:
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                    break;
                case 1:
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                    break;
                case 2:
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                    break;
            }
        }
        else
            PlayerPrefs.SetInt("anisotropic", anisotropic);
        #endregion

        if (mode_jeu == 1)
        {
            #region setup un joueur
            nb_joueur = PlayerPrefs.GetInt("nb_ia", nb_joueur);
            if (PlayerPrefs.HasKey("nb_ia"))
            {
                nb_joueur = PlayerPrefs.GetInt("nb_ia", nb_joueur);
            }
            else
            {
                PlayerPrefs.SetInt("nb_ia", nb_joueur);
            }

            nb_joueur++;

            all_spaceships = new GameObject[nb_joueur];

            choix = PlayerPrefs.GetInt("player", choix);
            if (PlayerPrefs.HasKey("player"))
            {
                choix = PlayerPrefs.GetInt("player", choix);
            }
            else
            {
                PlayerPrefs.SetInt("player", choix);
            }

            System.Random rnd = new System.Random();
            Vector3 pos = Vector3.zero;
            pos.Set(rnd.Next(-100, 100), rnd.Next(-10, 50), rnd.Next(-100, 100));

            //joueur
            switch (choix)
            {
                case 1:
                    all_spaceships[0] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                case 2:
                    all_spaceships[0] = Instantiate(vaisseau2, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                case 3:
                    all_spaceships[0] = Instantiate(vaisseau3, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                default:
                    all_spaceships[0] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
            }


            //IAs
            for (int i = 1; i < nb_joueur; i++)
            {
                pos = Vector3.zero;
                pos.Set(rnd.Next(-100, 100), rnd.Next(-10, 50), rnd.Next(-100, 100));

                try
                {
                    switch (rnd.Next(0, 3))
                    {
                        case 0:
                            all_spaceships[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                            break;
                        case 1:
                            all_spaceships[i] = Instantiate(IA2, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                            break;
                        case 2:
                            all_spaceships[i] = Instantiate(IA3, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                            break;
                        default:
                            all_spaceships[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                            break;
                    }
                }
                catch { }
            }

            Camera first = all_spaceships[0].GetComponentInChildren<Camera>();
            controlcamera firstcontrol = first.GetComponent<controlcamera>();
            firstcontrol.vvv = this.all_spaceships;

            for (int i = 0; i < all_spaceships.Length; i++)
            {
                vie life = all_spaceships[i].GetComponent<vie>();
                if (life == null)
                {
                    life = all_spaceships[i].GetComponentInChildren<vie>();
                }

                life.global_cam = this.camera;
                life.all_spaceships = this.all_spaceships;
                if (i == 0)
                    life.name = "player";
                else
                    life.name = "computer " + i;
            }
            #endregion
        }
        else if(mode_jeu == 2)
        {
            #region ecran splite
            nb_joueur = PlayerPrefs.GetInt("nb_ia", nb_joueur);
            if (PlayerPrefs.HasKey("nb_ia"))
            {
                nb_joueur = PlayerPrefs.GetInt("nb_ia", nb_joueur);
            }
            else
            {
                PlayerPrefs.SetInt("nb_ia", nb_joueur);
            }

            nb_joueur += 2;
            //aDebug.Log("nb joueur " + nb_joueur);

            all_spaceships = new GameObject[nb_joueur];

            choix = PlayerPrefs.GetInt("player", choix);
            if (PlayerPrefs.HasKey("player"))
            {
                choix = PlayerPrefs.GetInt("player", choix);
            }
            else
            {
                PlayerPrefs.SetInt("player", choix);
            }

            System.Random rnd = new System.Random();
            Vector3 pos = Vector3.zero;
            pos.Set(rnd.Next(-100, 100), rnd.Next(-10, 50), rnd.Next(-100, 100));

            //joueur
            switch (choix)
            {
                case 1:
                    all_spaceships[0] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    all_spaceships[1] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                case 2:
                    all_spaceships[0] = Instantiate(vaisseau2, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    all_spaceships[1] = Instantiate(vaisseau2, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                case 3:
                    all_spaceships[0] = Instantiate(vaisseau3, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    all_spaceships[1] = Instantiate(vaisseau3, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                default:
                    all_spaceships[0] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    all_spaceships[1] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
            }

            //IAs
            for (int i = 2; i < nb_joueur; i++)
            {
                pos = Vector3.zero;
                pos.Set(rnd.Next(-100, 50), rnd.Next(-10, 50), rnd.Next(-100, 100));

                switch (rnd.Next(0, 3))
                {
                    case 0:
                        all_spaceships[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                        break;
                    case 1:
                        all_spaceships[i] = Instantiate(IA2, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                        break;
                    case 2:
                        all_spaceships[i] = Instantiate(IA3, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                        break;
                    default:
                        all_spaceships[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                        break;
                }
            }

            Camera first = all_spaceships[0].GetComponentInChildren<Camera>();
            first.rect = new Rect(0, 0, 1f, 0.5f);
            controlcamera firstcontrol = first.GetComponent<controlcamera>();
            firstcontrol.vvv = this.all_spaceships;
            inputs toucheplayer1 = all_spaceships[0].GetComponentInChildren<inputs>();
            toucheplayer1.i = 1;

            Camera second = all_spaceships[1].GetComponentInChildren<Camera>();
            second.rect = new Rect(0, 0.5f, 1f, 0.5f);
            second.GetComponent<AudioListener>().enabled = false;
            controlcamera secondcontrol = second.GetComponent<controlcamera>();
            secondcontrol.vvv = this.all_spaceships;
            inputs toucheplayer2 = all_spaceships[1].GetComponentInChildren<inputs>();
            toucheplayer2.i = 2;

            

            for (int i = 0; i < all_spaceships.Length; i++)
            {
                vie life = all_spaceships[i].GetComponent<vie>();
                if (life == null)
                {
                    life = all_spaceships[i].GetComponentInChildren<vie>();
                }

                life.global_cam = this.camera;
                life.all_spaceships = this.all_spaceships;
                if (i <= 1)
                    life.name = "player " + (i + 1);
                else
                    life.name = "computer " + (i - 1);
            }
            #endregion
        }
        else if(mode_jeu == 3)
        {
            #region multijoueur
            menu = 0;
            choix = PlayerPrefs.GetInt("player", choix);

            if (PlayerPrefs.HasKey("player"))
            {
                choix = PlayerPrefs.GetInt("player", choix);
            }
            else
            {
                PlayerPrefs.SetInt("player", choix);
            }
            #endregion
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (b)
        {
            //Debug.Log("testa");

            try
            {
                if (mode_jeu == 1)
                {
                    for (int i = 1; i < nb_joueur; i++)
                    {
                        IA ordi = all_spaceships[i].gameObject.GetComponentInChildren<IA>();
                        ordi.liste = all_spaceships;
                    }
                }
                else if(mode_jeu == 2)
                {
                    for (int i = 2; i < nb_joueur; i++)
                    {
                        IA ordi = all_spaceships[i].gameObject.GetComponentInChildren<IA>();
                        ordi.liste = all_spaceships;
                    }
                }

                b = false;
                //Debug.Log("fait");
            }
            catch
            {
                b = true;
            }
        }
	}


    /*------------- POUR LE MULTI ------------------*/

    void OnGUI()
    {
        if (mode_jeu == 3)
        {
            GUI.skin = this.skin;

            switch (menu)
            {
                case 0:
                    set_name();
                    break;
                case 1:
                    select_connexion();
                    break;
                case 2:
                    menu_rejoindre();
                    break;
            }
        }
    }

    void set_name()
    {
		GUI.skin.label.fontSize = 20;
		GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 20, 300, 25), "Enter your name :");
        this.name = GUI.TextField(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 20, 300, 25), name);

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 300, 30), "Next"))
        {
            menu = 1;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 30), "Back to menu"))
        {
            Application.LoadLevel(0);
        }
    }

    void select_connexion()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 300, 30), "Host"))
        {
            all_spaceships = new GameObject[8];

            Network.InitializeServer(8, 25000, true);
            if (Network.peerType == NetworkPeerType.Server)
            {
                menu = 3;
                //nouveau_joueur();
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 30), "Join"))
        {
            menu = 2;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 30), "Back"))
        {
            menu = 0;
        }
    }

    void menu_rejoindre()
    {
		GUI.skin.label.fontSize = 20;
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 30), "Host IP : ");

        ip = GUI.TextField(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 300, 40), ip, 15);


        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 400, 25), "Join"))
        {
            Network.Connect(ip, port);
            if (Network.peerType == NetworkPeerType.Client)
            {
                menu = 3;
                //nouveau_joueur();
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 150, 400, 25), "Back"))
            menu = 1;
    }

    void OnServerInitialized()
    {
        nouveau_joueur();
    }

    void OnConnectedToServer()
    {
        menu = 3;
        nouveau_joueur();
    }

    void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        Destroy(vaisseau_multi);
        NetworkView.Destroy(vaisseau_multi);
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

    void nouveau_joueur()
    {
        Vector3 pos = Vector3.zero;

        System.Random rnd = new System.Random();
        pos.Set(rnd.Next(-100, 100), rnd.Next(-10, 50), rnd.Next(-100, 100));
        //pos.Set(50, 0, 0);
        //Debug.Log(Network.peerType);
        switch (choix)
        {
            case 1:
                vaisseau_multi = (GameObject)Network.Instantiate(vaisseau1_multi, pos, Quaternion.AngleAxis(0, Vector3.left), 0);
                break;
            case 2:
                vaisseau_multi = (GameObject)Network.Instantiate(vaisseau2_multi, pos, Quaternion.AngleAxis(0, Vector3.left), 0);
                break;
            case 3:
                vaisseau_multi = (GameObject)Network.Instantiate(vaisseau3_multi, pos, Quaternion.AngleAxis(0, Vector3.left), 0);
                break;
        }

        vie life = vaisseau_multi.GetComponent<vie>();
        if (life == null)
            life = vaisseau_multi.GetComponentInChildren<vie>();

        life.name = this.name;
        life.all_spaceships = this.all_spaceships;
        life.global_cam = this.camera;

        this.camera.enabled = false;

        int i = 0;
        while(i < all_spaceships.Length && all_spaceships[i] != null)
        {
            i++;
        }

        //Debug.Log(i);
        if(i < all_spaceships.Length)
        {
            all_spaceships[i] = vaisseau_multi;
            Camera first = all_spaceships[i].GetComponentInChildren<Camera>();
            controlcameramulti firstcontrol = first.GetComponent<controlcameramulti>();
            firstcontrol.vvv = this.all_spaceships;
        }
        
        //vaisseau.camera.enabled = true;
    }
}
