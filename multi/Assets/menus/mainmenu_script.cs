﻿using UnityEngine;
using System.Collections;

public class mainmenu_script : MonoBehaviour 
{
    private int choix_menu = 1;
    private float volume = 0.5f;
    public GUISkin skin;
    public Texture vaisseau1;
    public Texture vaisseau2;
    

	// Use this for initialization
	void Start () 
    {
        //GUI.skin = skin;
        volume = PlayerPrefs.GetFloat("Volume", volume);

        if(PlayerPrefs.HasKey("Volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", volume);
        }
	}

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.TextArea(new Rect(Screen.width / 3, Screen.height / 5, Screen.width*3/4, Screen.height / 5), "Flight Arena");
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
            choix_menu = 3;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 400, 25), "Multijoueur"))
        {
            // A MODIFIER
            Application.LoadLevel(2);
            //Application.Quit();
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 400, 25), "Options"))
        {
            choix_menu = 2;
            return;
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
        volume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 30, 100, 30), volume, 0.0f, 1.0f);
        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 30), ("Volume : " + (int)(10*volume)));

        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);

        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Retour"))
        {
            choix_menu = 1;
            return;
        }
    }

    void menu_selection()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 60, 400, 25), "Retour"))
        {
            choix_menu = 1;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 200, 200), vaisseau1))
        {
            PlayerPrefs.SetInt("vaisseau_joueur", 1);
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 200, 200, 200), vaisseau2))
        {
            PlayerPrefs.SetInt("vaisseau_joueur", 2);
            Application.LoadLevel(1);
        }
    }
}