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

        }
        else if(droite.detectCollisions)
        {

        }
        else//mettre a false
        {

        }
        if(haut.detectCollisions)
        {

        }
        else if(bas.detectCollisions)
        {

        }
        else//mettre a false
        {

        }

        deplacements();
    }
}
