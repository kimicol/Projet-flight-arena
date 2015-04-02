using UnityEngine;
using System.Collections;

public class vie : MonoBehaviour {

    private int pv = 5;
    //public Animation anim;

    void Start()
    {
        /*anim = gameObject.GetComponent<Animation>();
        if(anim == null)
        {
            Debug.Log("test");
        }*/
    }

    void Update()
    {
        if (pv <= 0 )//&& !anim.isPlaying)
        {
            //anim.Play();
            //Debug.Log("test2");
            Destroy(this);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            this.pv -= 1;
            //Debug.Log("test");
            Destroy(collision.gameObject);
        }
    }
}
