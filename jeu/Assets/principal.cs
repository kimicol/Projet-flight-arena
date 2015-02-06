using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class principal : Classevaisseau
{

    //Classevaisseau joueur;
    //List<projectile> balles;

	// Use this for initialization
	void Start () 
    {
        //this.Classevaisseau(10f, 5f, 100);
	}
	
	// Update is called once per frame
    /// <summary>
    /// Chaque frame du jeu
    /// </summary>
	void Update () 
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.haut();
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.bas();
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.droite();
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.gauche();
        }
        /*if(Input.GetKey(KeyCode.Space))
        {
            balles.Add(joueur.feu());
        }*/

        //Gérer la mort, les collisions, l'effacement des balles
	}

    /// <summary>
    /// Ce que fait le joueur à chaque tour
    /// </summary>
    /*void saisie()
    {

    }*/
}
