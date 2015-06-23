﻿using UnityEngine;
using System.Collections;

public class setting : MonoBehaviour 
{
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
    public static Rigidbody[] liste;
    int nb_joueur = 2;

	// Use this for initialization
	void Start () 
    {
        liste = new Rigidbody[nb_joueur];

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
                liste[0] = Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left)) as Rigidbody;
                break;
            case 2:
                liste[0] = Instantiate(vaisseau2, pos, Quaternion.AngleAxis(0, Vector3.left)) as Rigidbody;
                break;
            case 3:
                liste[0] = Instantiate(vaisseau3, pos, Quaternion.AngleAxis(0, Vector3.left)) as Rigidbody;
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
                    liste[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as Rigidbody;
                    break;
                case 1:
                    liste[i] = Instantiate(IA2, pos, Quaternion.AngleAxis(0, Vector3.left)) as Rigidbody;
                    break;
                case 2:
                    liste[i] = Instantiate(IA3, pos, Quaternion.AngleAxis(0, Vector3.left)) as Rigidbody;
                    break;
                default:
                    liste[i] = Instantiate(IA1, pos, Quaternion.AngleAxis(0, Vector3.left)) as Rigidbody;
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
