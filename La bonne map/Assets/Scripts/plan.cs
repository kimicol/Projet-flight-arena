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

    public bool is_on_right(Transform point, ref float distance)
    {
        Vector3 posi = point.position;
        distance = Mathf.Abs(a * posi.x + b * posi.y + c * posi.z + d) / Mathf.Sqrt(a*a + b*b + c*c);

        //Debug.Log("dist " + distance);

        return (a * posi.x + b * posi.y + c * posi.z + d > 0);
    }
}
