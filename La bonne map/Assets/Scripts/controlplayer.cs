using UnityEngine;
using System.Collections;

public class controlplayer : MonoBehaviour 
{
    public float v_max = 75f;
    private float vitesse = 0f;
    private float v_acceleration = 0.5f;

    private float rota_hor;
    private float rota_ver;
    private float rota_s;
    private float r_acceleration = 1f;

    private KeyCode Avancer = KeyCode.W;
    private KeyCode RotHaut = KeyCode.UpArrow;
    private KeyCode RotBas = KeyCode.DownArrow;
    private KeyCode PivGauche = KeyCode.A;
    private KeyCode PivDroite = KeyCode.D;
    private KeyCode RotGauche = KeyCode.LeftArrow;
    private KeyCode RotDroite = KeyCode.RightArrow;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        //rota_hor = transform.rotation.x;
        //rota_ver = transform.rotation.z;
        //rota_s = transform.rotation.w;

        if (Input.GetKey(RotHaut))
        {
            rota_ver += r_acceleration; 
        }
        if (Input.GetKey(RotBas))
        {
            rota_ver -= r_acceleration;
        }
        //transform.Rotate(Vector3.right * rota_ver * Time.deltaTime);

        if (Input.GetKey(RotGauche))
        {
            rota_hor += r_acceleration;
        }
        if (Input.GetKey(RotDroite))
        {
            rota_hor -= r_acceleration;
        }
        //transform.Rotate(Vector3.forward * rota_hor * Time.deltaTime);

        //tourner sur soi-meme
        if (Input.GetKey(PivDroite))
        {
            rota_s += r_acceleration;
        }
        if (Input.GetKey(PivGauche))
        {
            rota_s -= r_acceleration;
        }
        //transform.Rotate(Vector3.down * rota_s * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rota_ver, rota_s, rota_hor), Time.deltaTime);

        //Déplacement vers l'avant
        if (Input.GetKey(Avancer) && vitesse < v_max)
        {
            vitesse += v_acceleration;
        }
        else if(vitesse > 0)
        {
            vitesse -= v_acceleration;
        }
        if (Input.GetKey(KeyCode.O))
            vitesse -= v_acceleration;

        rigidbody.velocity = Vector3.zero;

        transform.Translate(Vector3.forward * Time.deltaTime * vitesse);
	}

    /*void FixedUpdate()
    {
        rigidbody.velocity = Vector3.zero;
    }*/
}
