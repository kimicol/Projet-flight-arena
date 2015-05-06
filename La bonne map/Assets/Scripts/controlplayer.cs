using UnityEngine;
using System.Collections;

public class controlplayer : MonoBehaviour 
{
    //DEPLACEMENTS
    public float v_max = 40f;
    private float vitesse = 0f;
    public float v_acceleration = 0.5f;

    private float rota_hor = 0;
    private float rota_ver = 0;
    private float rota_s = 0;
    public float r_acceleration = 3f;
    public float cap = 60f;

    protected bool av = false;
    protected bool RH = false;
    protected bool RB = false;
    protected bool PG = false;
    protected bool PD = false;
    protected bool RG = false;
    protected bool RD = false;
    protected bool fire = false;

    //TIRS
    public Rigidbody projectile;
    public Transform origine;
    public Transform origine2;
    private int i;
    private float recharge;
    private float tps_rech = 0.25f;

	// Use this for initialization
	void Start ()
    {
        i = 0;
        recharge = 0f;

	}

    protected void deplacements()
    {
        if ((RH || (rota_ver < 0 && !RB)) && rota_ver < cap)
        {
            rota_ver += r_acceleration;
        }
        if ((RB || (rota_ver > 0 && !RH)) && rota_ver > -cap)
        {
            rota_ver -= r_acceleration;
        }
        //transform.Rotate(Vector3.right * rota_ver * Time.deltaTime);

        if ((RG || (rota_hor < 0 && !RD)) && rota_hor < cap)
        {
            rota_hor += r_acceleration;
        }
        if ((RD || (rota_hor > 0 && !RG)) && rota_hor > -cap)
        {
            rota_hor -= r_acceleration;
        }
        //transform.Rotate(Vector3.forward * rota_hor * Time.deltaTime);

        //tourner sur soi-meme
        if ((PD || (rota_s < 0 && !PG)) && rota_s < cap)
        {
            rota_s += r_acceleration;
        }
        if ((PG || (rota_s > 0 && !PD)) && rota_s > -cap)
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

        if(fire)
        {
            tir();
        }
        if (recharge > 0f)
        {
            recharge -= Time.deltaTime;
        }
    }

    void tir()
    {
        if (recharge <= 0f)
        {
            Rigidbody instance;
            if (i == 0)
                instance = Instantiate(projectile, origine.position, origine.rotation) as Rigidbody;
            else
                instance = Instantiate(projectile, origine2.position, origine2.rotation) as Rigidbody;
            i = (i + 1) % 2;

            recharge = tps_rech;
        }
    }

    /*void FixedUpdate()
    {
        rigidbody.velocity = Vector3.zero;
    }*/
}
