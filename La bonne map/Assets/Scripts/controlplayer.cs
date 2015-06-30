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

    public bool av = false;
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
    private int j;
    private float recharge;
    private float tps_rech = 0.25f;
    public string vaisseau_nom;

    protected int mode_jeu = 1;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start ()
    {
        j = 0;
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
            projectile.name = this.gameObject.GetComponent<vie>().name;
            //Rigidbody instance;
            if (j == 0)
            {
                /*instance =*/
                if (mode_jeu == 3)
                {
                    Network.Instantiate(projectile, origine.position, origine.rotation, 0);
                }
                else
                    Instantiate(projectile, origine.position, origine.rotation);
            }
            else
            {
                /*instance =*/
                if(mode_jeu == 3)
                {
                    Network.Instantiate(projectile, origine2.position, origine2.rotation, 0);
                }
                else
                    Instantiate(projectile, origine2.position, origine2.rotation);
            }
            j = (j + 1) % 2;
            recharge = tps_rech;
        }
    }

    /*void FixedUpdate()
    {
        rigidbody.velocity = Vector3.zero;
    }*/
}
