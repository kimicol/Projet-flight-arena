using UnityEngine;
using System.Collections;

public class IA : controlplayer
{
    public ia_collid gauche;
    public ia_collid droite;
    public ia_collid haut;
    public ia_collid bas;

    public Transform point_devant;
    public Transform point_droite;
    public Transform point_haut;

    private plan horizontal;
    private plan vertical;
    private plan devant;

    public GameObject[] liste;

    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        horizontal = new plan(this.transform, new Vector3(point_haut.position.x - this.transform.position.x, point_haut.position.y - this.transform.position.y, point_haut.position.z - this.transform.position.z));
        vertical = new plan(this.transform, new Vector3(point_droite.position.x - this.transform.position.x, point_droite.position.y - this.transform.position.y, point_droite.position.z - this.transform.position.z));
        devant = new plan(this.transform, new Vector3(point_devant.position.x - this.transform.position.x, point_devant.position.y - this.transform.position.y, point_devant.position.z - this.transform.position.z));

        //Choose the enemy
        Transform cible = this.liste[0].transform;
        float distance = Vector3.Distance(this.transform.position, cible.position);
        for (int i = 1; i < this.liste.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, this.liste[i].transform.position) > 1 && distance > Vector3.Distance(this.transform.position, this.liste[i].transform.position))
            {
                cible = this.liste[i].transform;
                distance = Vector3.Distance(this.transform.position, this.liste[i].transform.position);
            }
        }

        if (cible == this.liste[0].transform)

        //Follow the "cible"
        //RH = horizontal.is_on_right(cible);
        //RB = !RH;
        PD = vertical.is_on_right(cible);
        PG = !PD;

        /*
        //Dodge buildings
        fire = false;

        if(gauche.col)
        {
            PD = true;
            av = false;
        }
        else if(droite.col)
        {
            PG = true;
            av = false;
        }
        else//mettre a false
        {
            PG = false;
            PD = false;
            av = true;
        }

        if(haut.col)
        {
            RH = true;
            av = false;
        }
        else if(bas.col)
        {
            RB = true;
            av = false;
        }
        else//mettre a false
        {
            RB = false;
            RH = false;
        }
        */
        
        //A RETIRER
        av = false;
         

        deplacements();
    }
}
