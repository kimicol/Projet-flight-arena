using UnityEngine;
using System.Collections;

public class vie : MonoBehaviour {

    private int pv = 5;

    void OnTriggerEnter(Collider objet)
    {
        balle feu = collider.gameObject.GetComponent<balle>();

        if(feu != null)
        {
            pv -= feu.degat;
            Destroy(feu);

            if(pv <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
