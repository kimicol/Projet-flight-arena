using UnityEngine;
using System.Collections;

public class Classevaisseau : OV
{
	
	//Variables

    /// <summary>
    /// Vie du vaisseau
    /// </summary>
    public int vie
    {
        get
        {
            return vie;
        }
        set
        {
            if (value < 0)
            {
                vie = 0;
            }
            else
            {
                vie = value;
            }
        }
    }

    public Classevaisseau(float vitesse, float rotation, int vie) : base(vitesse, rotation)
    {
        this.vie = vie;
    }

    //Méthodes

    /// <summary>
    /// Lorsque le vaisseau est déruit
    /// </summary>
	public void destruction()
	{

	}
    
    public projectile feu()//A COMPLETER
    {
        projectile tir = new projectile();
    }
}
