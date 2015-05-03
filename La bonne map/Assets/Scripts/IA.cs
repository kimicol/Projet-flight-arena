using UnityEngine;
using System.Collections;

public class IA : controlplayer
{
    public Rigidbody haut;
    public Rigidbody bas;
    public Rigidbody gauche;
    public Rigidbody droite;
	
	// Update is called once per frame
	void Update ()
    {
        av = true;
        fire = true;

        if(gauche.detectCollisions)
        {
            PD = true;
        }
        else if(droite.detectCollisions)
        {
            PG = true;
        }
        else//mettre a false
        {
            PD = false;
            PG = false;
        }
        if(haut.detectCollisions)
        {
            RB = true;
        }
        else if(bas.detectCollisions)
        {
            RH = true;
        }
        else//mettre a false
        {
            RB = false;
            RH = false;
        }

        deplacements();
    }
}
