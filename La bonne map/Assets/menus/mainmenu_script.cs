using UnityEngine;
using System.Collections;

public class mainmenu_script : MonoBehaviour 
{
    private int choix_menu = 1;
    private float volume = 0.5f;
    private int player = 1;
    public GUISkin skin;
    public Texture vaisseau1;
    public Texture vaisseau2;
    public Texture vaisseau3;
	public Texture logo;
    private int load_after = 0;

    private KeyCode[] all_keys;
    private KeyCode[] used_keys;
    private string[] name_keys;
    

	// Use this for initialization
	void Start () 
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

        //GUI.skin = skin;
        volume = PlayerPrefs.GetFloat("Volume", volume);
        if(PlayerPrefs.HasKey("Volume"))
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        else
            PlayerPrefs.SetFloat("Volume", volume);


        player = PlayerPrefs.GetInt("player", player);
        if(PlayerPrefs.HasKey("player"))
            player = PlayerPrefs.GetInt("player", player);
        else
            PlayerPrefs.SetInt("player", player);

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

    void OnGUI()
    {
        GUI.skin = skin;
        int taille = GUI.skin.label.fontSize;
        GUI.skin.label.fontSize = 70;
        GUI.Label(new Rect(Screen.width / 3, Screen.height / 5, Screen.width*3/4, Screen.height / 5), "Flight Arena");
        GUI.skin.label.fontSize = taille;
		GUI.DrawTexture (new Rect (Screen.width - 150, Screen.height - 150, 150, 150), logo);
        switch(choix_menu)
        {
            case 1:
                menu_principal();
                break;
            case 2:
                menu_options();
                break;
            case 3:
                menu_selection();
                break;
            case 4:
                menu_inputs();
                break;
            case 5:
                menu_type_multi();
                break;
            case 6:
                chargement_jeu();
                break;
        }
    }

    /// <summary>
    /// Le menu principal lorsqu'on arrive sur le jeu>
    /// Redirige vers jouer, multi, options ou quitter
    /// </summary>
    void menu_principal()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 30, 400, 25), "Un joueur"))
        {
            load_after = 1;
            choix_menu = 3;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Multijoueur"))
        {
            choix_menu = 5;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 400, 25), "Options"))
        {
            choix_menu = 2;
            //return;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Quitter"))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// Le menu des options
    /// </summary>
    void menu_options()
    {
        //Gestion du son
        volume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 40, 100, 30), volume, 0.0f, 1.0f);
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 80, 100, 30), ("Volume : " + (int)(10*volume)));

        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);

        //gestion de la qualite de l'image
        GUI.Label(new Rect(Screen.width / 6, Screen.height / 2, 200, 30), "Qualité de l'image :" );

        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            if (GUI.Button(new Rect(10 * (i + 1) + i * (Screen.width / QualitySettings.names.Length - 10), Screen.height / 2 + 40, Screen.width / QualitySettings.names.Length - (QualitySettings.names.Length + 1) * 10, 30), QualitySettings.names[i]))
            {
                QualitySettings.SetQualityLevel(i, true);
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 100, 400, 25), "Clavier"))
        {
            choix_menu = 4;
            return;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 200, 400, 25), "Retour"))
        {
            choix_menu = 1;
            return;
        }
    }

    void menu_selection()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 150, 400, 25), "Retour"))
        {
            choix_menu = 1;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 150, 150), vaisseau1))
        {
            PlayerPrefs.SetInt("player", 1);
            choix_menu = 6;
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 200, 150, 150), vaisseau2))
        {
            PlayerPrefs.SetInt("player", 2);
            choix_menu = 6;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 150, 150), vaisseau3))
        {
            PlayerPrefs.SetInt("player", 3);
            choix_menu = 6;
        }
    }

    void menu_inputs()
    {
        Event e = Event.current;

        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 80, 30), "Avancer");
        if (GUI.Button(new Rect(Screen.width / 2 + 100, Screen.height / 2, 50, 30), name_keys[0]))
        {
            e = Event.current;

            if (e.isKey)
            {
                Debug.Log("test2");
                used_keys[0] = e.keyCode;
                name_keys[0] = used_keys[0].ToString();
                Debug.Log(used_keys[0].ToString());
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 200, 400, 25), "Retour"))
        {
            choix_menu = 2;
            return;
        }
    }

    void menu_type_multi()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 25), "2 joueurs, écran séparé"))
        {
            load_after = 2;
            choix_menu = 3;
            //Application.Quit();
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Multijoueur en LAN"))
        {
            load_after = 3;
            choix_menu = 3;
            //Application.Quit();
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 50, 400, 25), "Retour"))
        {
            choix_menu = 1;
        }
    }

    void chargement_jeu()
    {
        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 20, 150, 40), "Chargements ...");

        switch(load_after)
        {
            case 1:
                //un joueur
                Application.LoadLevel(1);
                break;
            case 2:
                //ecran spilte
                Application.LoadLevel(2);
                break;
            case 3:
                //multi reseau
                Application.LoadLevel(3);
                break;
        }
    }
}
