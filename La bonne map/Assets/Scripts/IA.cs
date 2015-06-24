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
        horizontal = new plan(this.gameObject.rigidbody.transform, new Vector3(point_haut.position.x - this.gameObject.rigidbody.transform.position.x, point_haut.position.y - this.gameObject.rigidbody.transform.position.y, point_haut.position.z - this.gameObject.rigidbody.transform.position.z));
        vertical = new plan(this.gameObject.rigidbody.transform, new Vector3(point_droite.position.x - this.gameObject.rigidbody.transform.position.x, point_droite.position.y - this.gameObject.rigidbody.transform.position.y, point_droite.position.z - this.gameObject.rigidbody.transform.position.z));
        devant = new plan(this.gameObject.rigidbody.transform, new Vector3(point_devant.position.x - this.gameObject.rigidbody.transform.position.x, point_devant.position.y - this.gameObject.rigidbody.transform.position.y, point_devant.position.z - this.gameObject.rigidbody.transform.position.z));

        //Choose the enemy
        Transform cible = this.liste[0].gameObject.rigidbody.transform;
        float distance = Vector3.Distance(this.gameObject.rigidbody.transform.position, cible.position);
        for (int i = 1; i < this.liste.Length; i++)
        {
            if (Vector3.Distance(this.gameObject.rigidbody.transform.position, this.liste[i].gameObject.rigidbody.transform.position) > 1 && distance > Vector3.Distance(this.gameObject.rigidbody.transform.position, this.liste[i].gameObject.rigidbody.transform.position))
            {
                cible = this.liste[i].gameObject.rigidbody.transform;
                distance = Vector3.Distance(this.gameObject.rigidbody.transform.position, this.liste[i].gameObject.rigidbody.transform.position);
            }
        }
        
        //Follow the "cible"
        /*
        RB = horizontal.is_on_right(cible);
        RH = !RB;
        PD = vertical.is_on_right(cible);
        PG = !PD;
        */
       
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
            float distance_plan = 0f;
            bool is_in_front = devant.is_on_right(cible, ref distance_plan);
            bool on_right = vertical.is_on_right(cible, ref distance_plan);
            PD = on_right && (distance_plan >= 10 || !is_in_front);
            PG = !on_right && (distance_plan >= 10 || !is_in_front);
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
            float distance_plan_bis = 0f;
            bool is_in_front_bis = devant.is_on_right(cible, ref distance_plan_bis);
            bool on_right = horizontal.is_on_right(cible, ref distance_plan_bis);
            RB = on_right && (distance_plan_bis >= 10 || !is_in_front_bis);
            RH = !on_right && (distance_plan_bis >= 10 || !is_in_front_bis);
        }

        //av = false;
         
        deplacements();
    }
}
