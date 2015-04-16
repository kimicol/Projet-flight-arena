using UnityEngine;
using System.Collections;

public class tir : MonoBehaviour {

    public Rigidbody projectile;
    public Transform origine;
    public Transform origine2;
    public KeyCode input = KeyCode.Space;
    private int i;
    //public int force = 10000;

    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input))
        {
            //Debug.Log("bla");
            Rigidbody instance;
            if(i == 0)
                instance = Instantiate(projectile, origine.position, origine.rotation) as Rigidbody;
            else
                instance = Instantiate(projectile, origine2.position, origine2.rotation) as Rigidbody;
            i = (i + 1) % 2;
            //instance.AddForce(origine.forward * force);
        }
    }
}
