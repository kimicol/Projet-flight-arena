using UnityEngine;
using System.Collections;

public class inputs : controlplayer
{

    public KeyCode Avancer = KeyCode.W;
    public KeyCode RotHaut = KeyCode.UpArrow;
    public KeyCode RotBas = KeyCode.DownArrow;
    public KeyCode PivGauche = KeyCode.A;
    public KeyCode PivDroite = KeyCode.D;
    public KeyCode RotGauche = KeyCode.LeftArrow;
    public KeyCode RotDroite = KeyCode.RightArrow;
    public KeyCode feu = KeyCode.Space;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () 
    {
        av = Input.GetKey(Avancer);
        RH = Input.GetKey(RotHaut);
        RB = Input.GetKey(RotBas);
        PG = Input.GetKey(PivGauche);
        PD = Input.GetKey(PivDroite);
        RG = Input.GetKey(RotGauche);
        RD = Input.GetKey(RotDroite);
        fire = Input.GetKey(feu);

        deplacements();
	}
}
