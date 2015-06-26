using UnityEngine;
using System.Collections;

public class setting : MonoBehaviour 
{
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
    private GameObject[] temp;

    bool b = true;

	// Use this for initialization
	void Start ()
    {
        #region PlayerPrefs
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

        nb_joueur = PlayerPrefs.GetInt("nb_ia", nb_joueur);
        if (PlayerPrefs.HasKey("nb_ia"))
        {
            choix = PlayerPrefs.GetInt("nb_ia", nb_joueur);
        }
        else
        {
            PlayerPrefs.SetInt("player", choix);
        }

        nb_joueur++;

        temp = new GameObject[nb_joueur];

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
        pos.Set(rnd.Next(-150, 50), rnd.Next(-50, 20), rnd.Next(-170, 100));

        //joueur
        switch(choix)
        {
            case 1:
                temp[0] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                break;
            case 2:
                temp[0] = Instantiate(vaisseau2, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                break;
            case 3:
                temp[0] = Instantiate(vaisseau3, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                break;
            default:
                temp[0] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                break;
        }


        //IAs
        for (int i = 1; i < nb_joueur; i++)
        {
            pos = Vector3.zero;
            pos.Set(rnd.Next(-150, 50), rnd.Next(-50, 20), rnd.Next(-170, 100));

            switch (rnd.Next(0, 3))
            {
                case 0:
                    temp[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                case 1:
                    temp[i] = Instantiate(IA2, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                case 2:
                    temp[i] = Instantiate(IA3, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
                default:
                    temp[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as GameObject;
                    break;
            }
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
                for (int i = 1; i < nb_joueur; i++)
                {
                    IA ordi = temp[i].gameObject.GetComponentInChildren<IA>();
                    ordi.liste = temp;
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
}
