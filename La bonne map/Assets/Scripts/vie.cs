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
            Destroy(this);
        }
    }
}
