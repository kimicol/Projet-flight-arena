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
        Transform pos = this.transform;

        horizontal = new plan(pos, new Vector3(point_haut.position.x - pos.position.x, point_haut.position.y - pos.position.y, point_haut.position.z - pos.position.z));
        vertical = new plan(pos, new Vector3(point_droite.position.x - pos.position.x, point_droite.position.y - pos.position.y, point_droite.position.z - pos.position.z));
        devant = new plan(pos, new Vector3(point_devant.position.x - pos.position.x, point_devant.position.y - pos.position.y, point_devant.position.z - pos.position.z));

        //Choose the enemy
        Transform cible = this.liste[0].gameObject.GetComponentInChildren<Transform>();
        float distance = Vector3.Distance(pos.position, cible.position);
        for (int i = 1; i < this.liste.Length; i++)
        {
            if (Vector3.Distance(pos.position, this.liste[i].gameObject.GetComponentInChildren<Transform>().position) > 1 && distance > Vector3.Distance(pos.position, this.liste[i].gameObject.GetComponentInChildren<Transform>().position))
            {
                cible = this.liste[i].gameObject.GetComponentInChildren<Transform>();
                distance = Vector3.Distance(pos.position, this.liste[i].gameObject.GetComponentInChildren<Transform>().position);
            }
        }

        Debug.Log("Child " + gameObject.transform.childCount);
        
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
