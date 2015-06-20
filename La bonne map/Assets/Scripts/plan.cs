using UnityEngine;
using System.Collections;

public class plan
{
    private float a, b, c, d;

    public plan(Transform point, Vector3 vecteur)
    {
        a = vecteur.x;
        b = vecteur.y;
        c = vecteur.z;
        d = - a * point.position.x - b * point.position.y - c * point.position.z;
    }

    public bool is_on_right(Transform point)
    {
        return (a * point.position.x + b * point.position.y + c * point.position.z + d > 0);
    }
}
