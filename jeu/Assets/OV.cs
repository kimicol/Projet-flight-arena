using UnityEngine;
using System.Collections;

public class OV : MonoBehaviour
{

    /// <summary>
    /// Vitesse de rotation ou maniabilité
    /// </summary>
    public float rotation;

    /// <summary>
    /// Vitesse vers l'avant
    /// </summary>
    public float vitesse;


    /// <summary>
    /// Méthode pour avancer
    /// </summary>
    public void avancer()
    {
        this.transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
    }

    //Fonctions de rotations
    public void haut()
    {
        transform.Rotate(Vector3.up * this.rotation * Time.deltaTime);
    }
    public void bas()
    {
        transform.Rotate(Vector3.down * this.rotation * Time.deltaTime);
    }
    public void gauche()
    {
        transform.Rotate(Vector3.left * this.rotation * Time.deltaTime);
    }
    public void droite()
    {
        transform.Rotate(Vector3.right * this.rotation * Time.deltaTime);
    }
}
