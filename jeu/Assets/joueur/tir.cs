using UnityEngine;
using System.Collections;

public class tir : MonoBehaviour {

    public Rigidbody projectile;
    public Transform origine;
    //public int force = 10000;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("bla");
            Rigidbody instance;
            instance = Instantiate(projectile, origine.position, origine.rotation) as Rigidbody;
            //instance.AddForce(origine.forward * force);
        }
    }
}
