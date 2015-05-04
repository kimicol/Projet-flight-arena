using UnityEngine;
using System.Collections;

public class IA : controlplayer
{
    public ia_collid gauche;
    public ia_collid droite;
    public ia_collid haut;
    public ia_collid bas;
	
	// Update is called once per frame
	void Update ()
    {
        av = true;
        fire = true;

        if(gauche.col)
        {
            PD = true;
        }
        else if(droite.col)
        {
            PG = true;
        }
        else//mettre a false
        {
            PD = false;
            PG = false;
        }
        if(haut.col)
        {
            RB = true;
        }
        else if(bas.col)
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
