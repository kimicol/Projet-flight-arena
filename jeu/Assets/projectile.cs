using UnityEngine;
using System.Collections;

public class projectile : OV
{
    int degat;

    public projectile(float vitesse, float rotation, int degat): base(vitesse, rotation)
    {
        this.degat = degat;
    }

    public void toucher()
    {

    }
}
