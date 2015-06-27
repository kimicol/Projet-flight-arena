using UnityEngine;
using System.Collections;

public class flamme_script : MonoBehaviour
{
    public GameObject otherObject;
    private vie VI;
    private controlplayer cpl;

	// Use this for initialization
    void Start()
    {
        VI = otherObject.GetComponent<vie>();
        cpl = otherObject.GetComponent<controlplayer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (VI.current_life > 0)
        {
            this.particleSystem.enableEmission = cpl.av;
        }
        else
        {
            this.particleSystem.enableEmission = false;
        }
	}
}
