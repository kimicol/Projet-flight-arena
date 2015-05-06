using UnityEngine;
using System.Collections;

public class setting : MonoBehaviour 
{
    public GameObject vaisseau1;
    public GameObject vaisseau2;
    public GameObject vaisseau3;
    private int choix = 1;
    private Random rnd;

	// Use this for initialization
	void Start () 
    {
        choix = PlayerPrefs.GetInt("player", choix);

        if (PlayerPrefs.HasKey("player"))
        {
            choix = PlayerPrefs.GetInt("player", choix);
        }
        else
        {
            PlayerPrefs.SetInt("player", choix);
        }

        System.Random rnd = new System.Random();
        Vector3 pos = Vector3.zero;
        pos.Set(rnd.Next(-150, 50), rnd.Next(-50, 20), rnd.Next(-170, 100));

        switch(choix)
        {
            case 1:
                Instantiate(vaisseau1, pos, Quaternion.AngleAxis(0, Vector3.left));
                break;
            case 2:
                Instantiate(vaisseau2, pos, Quaternion.AngleAxis(0, Vector3.left));
                break;
            case 3:
                Instantiate(vaisseau3, pos, Quaternion.AngleAxis(0, Vector3.left));
                break;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
