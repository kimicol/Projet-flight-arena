using UnityEngine;
using System.Collections;

public class inputs : controlplayer
{

    private KeyCode Avancer = KeyCode.W;
    private KeyCode RotHaut = KeyCode.UpArrow;
    private KeyCode RotBas = KeyCode.DownArrow;
    private KeyCode PivGauche = KeyCode.A;
    private KeyCode PivDroite = KeyCode.D;
    private KeyCode RotGauche = KeyCode.LeftArrow;
    private KeyCode RotDroite = KeyCode.RightArrow;

	// Use this for initialization
	void Start () 
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

        deplacements();
	}
}
