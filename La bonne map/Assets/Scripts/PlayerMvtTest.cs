using UnityEngine;
using System.Collections;

public class PlayerMvtTest : MonoBehaviour
{
    private float v_maxtest = 1.2f;
    private float vitesse = 0f;
    public float v_acceleration = 0.5f;
    private float cfrott = 0;


    public float r_acceleration = 1f;
    public float cap = 100f;

    protected bool av = false;
    protected bool bk = false;
    protected bool RH = false;
    protected bool RB = false;
    protected bool PG = false;
    protected bool PD = false;
    protected bool RG = false;
    protected bool RD = false;

    private float vitesse_t0 = 2f;
    private float masse = 1f;
    private float acell_max = 0.5f;
    private float acell = 1;
    private float F = 0;
    private float frottement = 0;
    Vector3 john = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    protected void deplacements()
    {
        cfrott = acell_max / (v_maxtest * v_maxtest);
        Debug.Log("val cfrott :" + cfrott + " val acell_max :" + acell_max + " val v_maxtest :" + v_maxtest);
        frottement = cfrott * john.z * john.z; // cap frot 2 cap vit 1.41
        if (av)
        {
            acell = acell_max;
        }
        else if (bk)
        {
            if (john.z > 0)
            {
                acell = -acell_max / 2;
            }
            else
            {
                acell = 0;
            }
        }
        else
        {
            acell = 0;
        }
        //		if (john.z >0)
        //		{
        F = acell - frottement;
        //		}
        //		else {
        //			john.Set(john.x,john.y,0);
        //				}
        Debug.Log("valeur avancer : " + av + " valeur back :" + bk + " valeur frott :" + frottement + " john.z: " + john.z);
        Debug.Log("rigidebody z :" + rigidbody.velocity.z + " y :" + rigidbody.velocity.y + " x :" + rigidbody.velocity.x);
        //rigidbody.velocity = Vector3.zero;
        john.Set(0, 0, john.z + (F / masse) * Time.deltaTime);
        transform.Translate(john);
        Debug.Log("F :" + F + " acell :" + acell);
    }
}
