using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class principal : MonoBehaviour {

    Classevaisseau joueur;
    List<projectile> balles;

	// Use this for initialization
	void Start () 
    {
        joueur = new Classevaisseau(10f, 5f, 100);
        balles = new List<projectile>();
	}
	
	// Update is called once per frame
    /// <summary>
    /// Chaque frame du jeu
    /// </summary>
	void Update () 
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            joueur.haut();
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            joueur.bas();
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            joueur.droite();
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            joueur.gauche();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            balles.Add(joueur.feu());
        }

        //Gérer la mort, les collisions, l'effacement des balles
	}

    /// <summary>
    /// Ce que fait le joueur à chaque tour
    /// </summary>
    void saisie()
    {

    }
}
