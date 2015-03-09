using UnityEngine;
using System.Collections;

public class controlplayer : MonoBehaviour 
{
    private float v_max = 200f;
    private float vitesse = 0f;
    private float v_acceleration = 5f;

    private float r_max = 50f;
    private float rota_hor = 0f;
    private float rota_ver = 0f;
    private float rota_s = 0f;
    private float r_acceleration = 5f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKey(KeyCode.UpArrow) || (!Input.GetKey(KeyCode.DownArrow) &&rota_ver < 0f))
        {
            if(rota_ver < r_max)
                rota_ver += r_acceleration; 
        }
        else if (Input.GetKey(KeyCode.DownArrow) || rota_ver > 0f)
        {
            if(rota_ver > -r_max)
                rota_ver -= r_acceleration;
        }
        transform.Rotate(Vector3.right * rota_ver * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) || (!Input.GetKey(KeyCode.A) && rota_hor < 0f))
        {
            if(rota_hor < r_max)
                rota_hor += r_acceleration;
        }
        else if (Input.GetKey(KeyCode.A) || rota_hor > 0f)
        {
            if(rota_hor > -r_max)
                rota_hor -= r_acceleration;
        }
        transform.Rotate(Vector3.up * rota_hor * Time.deltaTime);

        //tourner sur soi-meme
        if (Input.GetKey(KeyCode.LeftArrow) || (!Input.GetKey(KeyCode.RightArrow) && rota_s < 0f))
        {
            if (rota_s < r_max)
                rota_s += r_acceleration;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || rota_s > 0f)
        {
            if (rota_s > -r_max)
                rota_s -= r_acceleration;
        }
        transform.Rotate(Vector3.forward * rota_s * Time.deltaTime);

        //Déplacement vers l'avant
        if(Input.GetKey(KeyCode.W) && vitesse < v_max)
        {
            vitesse += v_acceleration;
        }
        else if(vitesse > 0)
        {
            vitesse -= v_acceleration;
        }
        transform.Translate(-Vector3.back * Time.deltaTime * vitesse);
	}
}
