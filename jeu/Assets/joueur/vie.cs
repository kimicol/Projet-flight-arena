using UnityEngine;
using System.Collections;

public class vie : MonoBehaviour {

    private int pv = 5;

    void Start()
    {

    }

    void Update()
    {
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
