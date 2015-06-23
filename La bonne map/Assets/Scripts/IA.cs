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
        horizontal = new plan(this.rigidbody.transform, new Vector3(point_haut.position.x - this.rigidbody.transform.position.x, point_haut.position.y - this.rigidbody.transform.position.y, point_haut.position.z - this.rigidbody.transform.position.z));
        vertical = new plan(this.rigidbody.transform, new Vector3(point_droite.position.x - this.rigidbody.transform.position.x, point_droite.position.y - this.rigidbody.transform.position.y, point_droite.position.z - this.rigidbody.transform.position.z));
        devant = new plan(this.rigidbody.transform, new Vector3(point_devant.position.x - this.rigidbody.transform.position.x, point_devant.position.y - this.rigidbody.transform.position.y, point_devant.position.z - this.rigidbody.transform.position.z));

        //Choose the enemy
        Transform cible = this.liste[0].rigidbody.transform;
        float distance = Vector3.Distance(this.rigidbody.transform.position, cible.position);
        for (int i = 1; i < this.liste.Length; i++)
        {
            if (Vector3.Distance(this.rigidbody.transform.position, this.liste[i].rigidbody.transform.position) > 1 && distance > Vector3.Distance(this.rigidbody.transform.position, this.liste[i].rigidbody.transform.position))
            {
                cible = this.liste[i].rigidbody.transform;
                distance = Vector3.Distance(this.rigidbody.transform.position, this.liste[i].rigidbody.transform.position);
            }
        }

        //Follow the "cible"
        RB = horizontal.is_on_right(cible);
        RH = !RB;
        PD = vertical.is_on_right(cible);
        PG = !PD;

       
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
            //PG = false;
            //PD = false;
            PD = vertical.is_on_right(cible);
            PG = !PD;
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
            //RB = false;
            //RH = false;
            RB = horizontal.is_on_right(cible);
            RH = !RB;
        }
         
        deplacements();
    }
}
