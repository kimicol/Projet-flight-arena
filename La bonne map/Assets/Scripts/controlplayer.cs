using UnityEngine;
using System.Collections;

public class controlplayer : MonoBehaviour 
{
    public float v_max = 75f;
    private float vitesse = 0f;
    private float v_acceleration = 0.5f;

    private float r_max = 50f;
    private float rota_hor = 0f;
    private float rota_ver = 0f;
    private float rota_s = 0f;
    private float r_acceleration = 4f;

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
        if (Input.GetKey(RotHaut) || (!Input.GetKey(RotBas) && rota_ver < 0f))
        {
            if(rota_ver < r_max)
                rota_ver += r_acceleration; 
        }
        else if (Input.GetKey(RotBas) || rota_ver > 0f)
        {
            if(rota_ver > -r_max)
                rota_ver -= r_acceleration;
        }
        transform.Rotate(Vector3.right * rota_ver * Time.deltaTime);

        if (Input.GetKey(PivDroite) || (!Input.GetKey(PivGauche) && rota_hor < 0f))
        {
            if(rota_hor < r_max)
                rota_hor += r_acceleration;
        }
        else if (Input.GetKey(PivGauche) || rota_hor > 0f)
        {
            if(rota_hor > -r_max)
                rota_hor -= r_acceleration;
        }
        transform.Rotate(Vector3.forward * rota_hor * Time.deltaTime);

        //tourner sur soi-meme
        if (Input.GetKey(RotGauche) || (!Input.GetKey(RotDroite) && rota_s < 0f))
        {
            if (rota_s < r_max)
                rota_s += r_acceleration;
        }
        else if (Input.GetKey(RotDroite) || rota_s > 0f)
        {
            if (rota_s > -r_max)
                rota_s -= r_acceleration;
        }
        transform.Rotate(Vector3.down * rota_s * Time.deltaTime);

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

        transform.Translate(Vector3.down * Time.deltaTime * vitesse);
	}

    void FixedUpdate()
    {
        rigidbody.velocity = Vector3.zero;
    }
}
