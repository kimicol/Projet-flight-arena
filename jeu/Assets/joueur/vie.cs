using UnityEngine;
using System.Collections;

public class vie : MonoBehaviour {

    private int pv = 5;
    public Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        if(anim == null)
        {
            Debug.Log("test");
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("bla");
            pv = 0;
        }

        if (pv <= 0 )//&& !anim.isPlaying)
        {
            //anim.Play();
            DestroyObject(gameObject, 2);
        }
    }

    void OnTriggerEnter(Collider objet)
    {
        balle feu = collider.gameObject.GetComponent<balle>();

        if(feu != null)
        {
            pv -= feu.degat;
            Destroy(feu);
        }
    }
}
