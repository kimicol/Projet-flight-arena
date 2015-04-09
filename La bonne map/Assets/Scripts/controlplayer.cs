using UnityEngine;
using System.Collections;

public class controlplayer : MonoBehaviour 
{
    public float v_max = 75f;
    private float vitesse = 0f;
    private float v_acceleration = 0.5f;

    private float rota_hor = 0;
    private float rota_ver = 0;
    private float rota_s = 0;
    private float r_acceleration = 1f;

    protected bool av = false;
    protected bool RH = false;
    protected bool RB = false;
    protected bool PG = false;
    protected bool PD = false;
    protected bool RG = false;
    protected bool RD = false;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    protected void deplacements()
    {
        if ((RH || (rota_ver < 0 && !RB)) && rota_ver < 170f)
        {
            rota_ver += r_acceleration;
        }
        if ((RB || (rota_ver > 0 && !RH)) && rota_ver > -170f)
        {
            rota_ver -= r_acceleration;
        }
        //transform.Rotate(Vector3.right * rota_ver * Time.deltaTime);

        if ((RG || (rota_hor < 0 && !RD)) && rota_hor < 170f)
        {
            rota_hor += r_acceleration;
        }
        if ((RD || (rota_hor > 0 && !RG)) && rota_hor > -170f)
        {
            rota_hor -= r_acceleration;
        }
        //transform.Rotate(Vector3.forward * rota_hor * Time.deltaTime);

        //tourner sur soi-meme
        if ((PD || (rota_s < 0 && !PG)) && rota_s < 170f)
        {
            rota_s += r_acceleration;
        }
        if ((PG || (rota_s > 0 && !PD)) && rota_s > -170f)
        {
            rota_s -= r_acceleration;
        }
        //transform.Rotate(Vector3.down * rota_s * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(rota_ver, rota_s, rota_hor), Time.deltaTime);

        //Déplacement vers l'avant
        if (av && vitesse < v_max)
        {
            vitesse += v_acceleration;
        }
        else if (vitesse > 0)
        {
            vitesse -= v_acceleration;
        }

        rigidbody.velocity = Vector3.zero;

        transform.Translate(Vector3.forward * Time.deltaTime * vitesse);
    }

    /*void FixedUpdate()
    {
        rigidbody.velocity = Vector3.zero;
    }*/
}
