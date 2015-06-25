using UnityEngine;
using System.Collections;
using UnityEditor;

public class menu_pause : MonoBehaviour
{
    #region attribut
    int paused = 0;
    int aliasing = 8; // a changer 
    int anisotropic;
    private float volume;
    bool changed_sound = false;
    public GUISkin skin;
    AudioListener main;

    private int qualite_image = 0;
    private int son = 0;

    private KeyCode[] all_keys;
    private KeyCode[] used_keys;
    private string[] name_keys;

    private KeyCode change = KeyCode.None;
    private float t = 0f;
    private int c = -1;
    private bool b = true;
    private bool un_joueur = true;
    #endregion

    void Start()
    {
        #region keys
        all_keys = new KeyCode[63];
        all_keys[0] = KeyCode.Ampersand;
        all_keys[1] = KeyCode.A;
        all_keys[2] = KeyCode.AltGr;
        all_keys[3] = KeyCode.Alpha0;
        all_keys[4] = KeyCode.Alpha1;
        all_keys[5] = KeyCode.Alpha2;
        all_keys[6] = KeyCode.Alpha3;
        all_keys[7] = KeyCode.Alpha4;
        all_keys[8] = KeyCode.Alpha5;
        all_keys[9] = KeyCode.Alpha6;
        all_keys[10] = KeyCode.Alpha7;
        all_keys[11] = KeyCode.Alpha8;
        all_keys[12] = KeyCode.Alpha9;
        all_keys[13] = KeyCode.B;
        all_keys[14] = KeyCode.C;
        all_keys[15] = KeyCode.D;
        all_keys[16] = KeyCode.Delete;
        all_keys[17] = KeyCode.DownArrow;
        all_keys[18] = KeyCode.E;
        all_keys[19] = KeyCode.F;
        all_keys[20] = KeyCode.G;
        all_keys[21] = KeyCode.H;
        all_keys[22] = KeyCode.I;
        all_keys[23] = KeyCode.J;
        all_keys[24] = KeyCode.K;
        all_keys[25] = KeyCode.Keypad0;
        all_keys[26] = KeyCode.Keypad1;
        all_keys[27] = KeyCode.Keypad2;
        all_keys[28] = KeyCode.Keypad3;
        all_keys[29] = KeyCode.Keypad4;
        all_keys[30] = KeyCode.Keypad5;
        all_keys[31] = KeyCode.Keypad6;
        all_keys[32] = KeyCode.Keypad7;
        all_keys[33] = KeyCode.Keypad8;
        all_keys[34] = KeyCode.Keypad9;
        all_keys[35] = KeyCode.KeypadEnter;
        all_keys[36] = KeyCode.L;
        all_keys[37] = KeyCode.LeftAlt;
        all_keys[38] = KeyCode.LeftArrow;
        all_keys[39] = KeyCode.LeftControl;
        all_keys[40] = KeyCode.LeftShift;
        all_keys[41] = KeyCode.M;
        all_keys[42] = KeyCode.N;
        all_keys[43] = KeyCode.O;
        all_keys[44] = KeyCode.P;
        all_keys[45] = KeyCode.Q;
        all_keys[46] = KeyCode.R;
        all_keys[47] = KeyCode.Return;
        all_keys[48] = KeyCode.RightAlt;
        all_keys[49] = KeyCode.RightArrow;
        all_keys[50] = KeyCode.RightControl;
        all_keys[51] = KeyCode.RightShift;
        all_keys[52] = KeyCode.S;
        all_keys[53] = KeyCode.Space;
        all_keys[54] = KeyCode.T;
        all_keys[55] = KeyCode.Tab;
        all_keys[56] = KeyCode.U;
        all_keys[57] = KeyCode.UpArrow;
        all_keys[58] = KeyCode.V;
        all_keys[59] = KeyCode.W;
        all_keys[60] = KeyCode.X;
        all_keys[61] = KeyCode.Y;
        all_keys[62] = KeyCode.Z;
        #endregion

        #region PlayerPrefs
        //volume = this.camera.audio.volume;
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

        used_keys = new KeyCode[24];
        name_keys = new string[24];
        #region joueur0
        used_keys[0] = KeyCode.W;
        used_keys[1] = KeyCode.UpArrow;
        used_keys[2] = KeyCode.DownArrow;
        used_keys[3] = KeyCode.A;
        used_keys[4] = KeyCode.D;
        used_keys[5] = KeyCode.LeftArrow;
        used_keys[6] = KeyCode.RightArrow;
        used_keys[7] = KeyCode.Space;
        #endregion
        #region joueur1
        used_keys[8] = KeyCode.W;
        used_keys[9] = KeyCode.U;
        used_keys[10] = KeyCode.J;
        used_keys[11] = KeyCode.A;
        used_keys[12] = KeyCode.D;
        used_keys[13] = KeyCode.H;
        used_keys[14] = KeyCode.K;
        used_keys[15] = KeyCode.Space;
        #endregion
        #region joueur2
        used_keys[16] = KeyCode.UpArrow;
        used_keys[17] = KeyCode.Keypad8;
        used_keys[18] = KeyCode.Keypad5;
        used_keys[19] = KeyCode.LeftArrow;
        used_keys[20] = KeyCode.RightArrow;
        used_keys[21] = KeyCode.Keypad4;
        used_keys[22] = KeyCode.Keypad6;
        used_keys[23] = KeyCode.Keypad0;
        #endregion
        for (int i = 0; i < used_keys.Length; i++)
        {
            name_keys[i] = used_keys[i].ToString();
        }

        #region get_prefs
        for (int i = 0; i < 3; i++)
        {
            name_keys[i * 8] = PlayerPrefs.GetString("avancer" + i, name_keys[8 * i]);
            if (PlayerPrefs.HasKey("avancer" + i))
                name_keys[i * 8] = PlayerPrefs.GetString("avancer" + i, name_keys[8 * i]);
            else
                PlayerPrefs.SetString("avancer" + i, name_keys[8 * i]);

            name_keys[i * 8 + 1] = PlayerPrefs.GetString("rothaut" + i, name_keys[8 * i + 1]);
            if (PlayerPrefs.HasKey("rothaut" + i))
                name_keys[i * 8 + 1] = PlayerPrefs.GetString("rothaut" + i, name_keys[8 * i + 1]);
            else
                PlayerPrefs.SetString("rothaut" + i, name_keys[8 * i + 1]);

            name_keys[i * 8 + 2] = PlayerPrefs.GetString("rotbas" + i, name_keys[8 * i + 2]);
            if (PlayerPrefs.HasKey("rotbas" + i))
                name_keys[i * 8 + 2] = PlayerPrefs.GetString("rotbas" + i, name_keys[8 * i + 2]);
            else
                PlayerPrefs.SetString("rotbas" + i, name_keys[8 * i + 2]);

            name_keys[i * 8 + 3] = PlayerPrefs.GetString("pivgauche" + i, name_keys[8 * i + 3]);
            if (PlayerPrefs.HasKey("pivgauche" + i))
                name_keys[i * 8 + 3] = PlayerPrefs.GetString("pivgauche" + i, name_keys[8 * i + 3]);
            else
                PlayerPrefs.SetString("pivgauche" + i, name_keys[8 * i + 3]);

            name_keys[i * 8 + 4] = PlayerPrefs.GetString("pivdroite" + i, name_keys[8 * i + 4]);
            if (PlayerPrefs.HasKey("pivdroite" + i))
                name_keys[i * 8 + 4] = PlayerPrefs.GetString("pivdroite" + i, name_keys[8 * i + 4]);
            else
                PlayerPrefs.SetString("pivdroite" + i, name_keys[8 * i + 4]);

            name_keys[i * 8 + 5] = PlayerPrefs.GetString("rotgauche" + i, name_keys[8 * i + 5]);
            if (PlayerPrefs.HasKey("rotgauche" + i))
                name_keys[i * 8 + 5] = PlayerPrefs.GetString("rotgauche" + i, name_keys[8 * i + 5]);
            else
                PlayerPrefs.SetString("rotgauche" + i, name_keys[8 * i + 5]);

            name_keys[i * 8 + 6] = PlayerPrefs.GetString("rotdroite" + i, name_keys[8 * i + 6]);
            if (PlayerPrefs.HasKey("rotdroite" + i))
                name_keys[i * 8 + 6] = PlayerPrefs.GetString("rotdroite" + i, name_keys[8 * i + 6]);
            else
                PlayerPrefs.SetString("rotdroite" + i, name_keys[8 * i + 6]);

            name_keys[i * 8 + 7] = PlayerPrefs.GetString("feu" + i, name_keys[8 * i + 7]);
            if (PlayerPrefs.HasKey("feu" + i))
                name_keys[i * 8 + 7] = PlayerPrefs.GetString("feu" + i, name_keys[8 * i + 7]);
            else
                PlayerPrefs.SetString("feu" + i, name_keys[8 * i + 7]);
        }
        #endregion

        for (int i = 0; i < used_keys.Length; i++)
        {
            int j = 0;
            while (j < all_keys.Length && all_keys[j].ToString() != name_keys[i])
                j++;
            if (j < all_keys.Length)
                used_keys[i] = all_keys[j];
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused == 0)
            {
                paused = 1;
                Time.timeScale = 0f;
            }
            else
            {
                paused = 0;
                Time.timeScale = 1f;
            }
        }
        if (changed_sound)
        {
            foreach (var a in FindObjectsOfType<AudioSource>()) // si split screen
                a.volume = volume;
            changed_sound = false;
        }
    }

    void OnGUI()
    {
        skin.label.fontSize = 70;
        GUI.skin = skin;

        if (paused != 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");
            skin.label.fontSize = 20;
            GUI.skin = skin;
        }

        if (paused == 1) // Menu principal
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au jeu"))
            { 
                paused = 0;
                Time.timeScale = 1f; 
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Options"))
                paused = 2; 
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Retour au menu du jeu"))
                Application.LoadLevel(0);
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Quitter le jeu"))
                Application.Quit();
        }
        else if (paused == 2) // option
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Retour au menu pause"))
            { paused = 1; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Son"))
            { paused = 3; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Réglage des touches"))
                paused = 4;
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Vidéo"))
            { paused = 5; }
        }
        else if (paused == 3) // son
        {
            #region son
            //Changement du volume
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Volume");
            volume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), volume, 0.0F, 1.0F); // A verifier sur quelle valeur est change et difference avec valeur du menu
            string lengthText = GUI.TextField(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 20, 300, 25), volume.ToString());
            float newLength;
            if (float.TryParse(lengthText, out newLength))
            {
                volume = newLength;
            }
            PlayerPrefs.SetFloat("Volume", volume);

            string[] toolbarStrings = new string[] { "Mono", "Stéréo", "Quad", "Surround", "5.1", "7.1" };
            int var = 0;
            var = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 50, 800, 25), var, toolbarStrings);
            switch (var)
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

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 140, 300, 25), "Retour au menu pause"))
            { paused = 1; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 25), "Retour au menu Options"))
            { paused = 2; }
            #endregion
        }
        else if (paused == 4) // Touches
        {
            #region touches
            menu_inputs();

            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 250, 300, 25), "Retour au menu Options"))
            { paused = 2; }
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 280, 300, 25), "Retour au menu pause"))
            { paused = 1; }
            #endregion
        }
        else if (paused == 5) // Video
        {
            #region video
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 160, 300, 25), "Anisotropic Textures");
            string[] toolbarStrings = new string[] { "Disable", "Enable", "Force Enable" };
            anisotropic = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 125, 800, 25), anisotropic, toolbarStrings);
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
            PlayerPrefs.SetInt("anisotropic", anisotropic);

            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 60, 300, 25), "Anti Aliasing");
            toolbarStrings = new string[] { "0", "2x", "4x", "8x" };
            aliasing = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 20, 800, 25), aliasing, toolbarStrings);
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
            PlayerPrefs.SetInt("aliasing", aliasing);

            bool coche = QualitySettings.softVegetation;
            coche = GUI.Toggle(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 20, 800, 25), coche, "Soft Particles");
            QualitySettings.softVegetation = coche;
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 60, 300, 25), "Luminosité");

            Light lt = GameObject.FindObjectOfType<Light>();
            float lumi = lt.intensity;
            lumi = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 100, 300, 25), lumi, 0.0F, 1.0F);
            string lengthText = GUI.TextField(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 125, 300, 25), lumi.ToString());
            float newLength;
            if (float.TryParse(lengthText, out newLength))
            {
                lt.intensity = newLength;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 180, 300, 25), "Retour au menu Options"))
            { paused = 2; }
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 220, 300, 25), "Retour au menu pause"))
            { paused = 1; }

            //Debug.Log("AA : " + temp + " filtre : " + temp2);
            #endregion
        }
    }

    /// <summary>
    /// Changer les touches pour le joueur
    /// </summary>
    void menu_inputs()
    {
        if (b)
        {
            if (un_joueur)
            {
                #region un_joueur
                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 120, 50), "Avancer");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 200, 150, 30), name_keys[0]))
                {
                    c = 0;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 120, 50), "Haut");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 150, 150, 30), name_keys[1]))
                {
                    c = 1;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 120, 50), "Bas");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 100, 150, 30), name_keys[2]))
                {
                    c = 2;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 120, 50), "Gauche");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 50, 150, 30), name_keys[3]))
                {
                    c = 3;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2, 120, 50), "Droite");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 30), name_keys[4]))
                {
                    c = 4;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 120, 50), "Rotation Gauche");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 50, 150, 30), name_keys[5]))
                {
                    c = 5;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 120, 50), "Rotation Droite");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 150, 30), name_keys[6]))
                {
                    c = 6;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 120, 50), "Tirer");
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 150, 150, 30), name_keys[7]))
                {
                    c = 7;
                    t = 5f;
                    b = false;
                }
                #endregion
            }
            else
            {
                #region joueurs_split
                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 200, 120, 50), "Avancer");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 150, 30), name_keys[8]))
                {
                    c = 8;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 150, 120, 50), "Haut");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 150, 30), name_keys[9]))
                {
                    c = 9;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 120, 50), "Bas");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 150, 30), name_keys[10]))
                {
                    c = 10;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 50, 120, 50), "Gauche");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 150, 30), name_keys[11]))
                {
                    c = 11;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2, 120, 50), "Droite");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 150, 30), name_keys[12]))
                {
                    c = 12;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 50, 120, 50), "Rotation Gauche");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 150, 30), name_keys[13]))
                {
                    c = 13;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 100, 120, 50), "Rotation Droite");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 150, 30), name_keys[14]))
                {
                    c = 14;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 150, 120, 50), "Tirer");
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 150, 30), name_keys[15]))
                {
                    c = 15;
                    t = 5f;
                    b = false;
                }

                //DEUXIEME JOUEUR
                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2 - 200, 120, 50), "Avancer");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 - 200, 150, 30), name_keys[16]))
                {
                    c = 16;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2 - 150, 120, 50), "Haut");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 - 150, 150, 30), name_keys[17]))
                {
                    c = 17;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2 - 100, 120, 50), "Bas");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 - 100, 150, 30), name_keys[18]))
                {
                    c = 18;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2 - 50, 120, 50), "Gauche");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 - 50, 150, 30), name_keys[19]))
                {
                    c = 19;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2, 120, 50), "Droite");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2, 150, 30), name_keys[20]))
                {
                    c = 20;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2 + 50, 120, 50), "Rotation Gauche");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 50, 150, 30), name_keys[21]))
                {
                    c = 21;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2 + 100, 120, 50), "Rotation Droite");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 100, 150, 30), name_keys[22]))
                {
                    c = 22;
                    t = 5f;
                    b = false;
                }

                GUI.Label(new Rect(Screen.width / 2 + 10, Screen.height / 2 + 150, 120, 50), "Tirer");
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 150, 150, 30), name_keys[23]))
                {
                    c = 23;
                    t = 5f;
                    b = false;
                }
                #endregion
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 200, 300, 25), "Joueur 1"))
                un_joueur = true;
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 200, 300, 25), "Deux joueurs (écran séparé)"))
                un_joueur = false;

            if (c >= 0 && change != KeyCode.None)
            {
                used_keys[c] = change;
                name_keys[c] = used_keys[c].ToString();
                c = -1;
                change = KeyCode.None;
                t = 0f;
            }
            else
            {
                #region get_prefs
                for (int i = 0; i < 3; i++)
                {
                    PlayerPrefs.SetString("avancer" + i, name_keys[8 * i]);
                    PlayerPrefs.SetString("rothaut" + i, name_keys[8 * i + 1]);
                    PlayerPrefs.SetString("rotbas" + i, name_keys[8 * i + 2]);
                    PlayerPrefs.SetString("pivgauche" + i, name_keys[8 * i + 3]);
                    PlayerPrefs.SetString("pivdroite" + i, name_keys[8 * i + 4]);
                    PlayerPrefs.SetString("rotgauche" + i, name_keys[8 * i + 5]);
                    PlayerPrefs.SetString("rotdroite" + i, name_keys[8 * i + 6]);
                    PlayerPrefs.SetString("feu" + i, name_keys[8 * i + 7]);
                }
                #endregion
            }
        }
        else
        {
            b = changement_touche();
        }
    }

    bool changement_touche()
    {
        if (Event.current.type == EventType.keyDown)
        {
            KeyCode input = Event.current.keyCode;

            int i = 0;
            while (i < all_keys.Length && all_keys[i] != input)
                i++;

            if(i < all_keys.Length)
                this.change = input;

            return true;
        }

        t -= Time.deltaTime;

        return t <= 0f;
    }
}
