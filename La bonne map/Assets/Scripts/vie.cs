using UnityEngine;
using System.Collections;

public class vie : MonoBehaviour {

    public int pv = 5;
    public int current_life;
    private bool killed;
    private int frag_limite = 5;
    public bool respawn = true;
    private Vector3 respawn_point;

    public Transform depart;
    public GUISkin skin;
    public Animation anim;

    void Start()
    {
        /*anim = gameObject.GetComponent<Animation>();
        if(anim == null)
        {
            Debug.Log("test");
        }*/
        current_life = pv;
        killed = false;
    }

    void Update()
    {
        if (current_life<= 0 )//&& !anim.isPlaying)
        {
            //anim.Play();
            if (!respawn)
            {
                DestroyObject(this.gameObject);
            }
            else
            {
                if (frag_limite >1)
                {
                    System.Random rnd = new System.Random();
                    respawn_point.Set(rnd.Next(-120,120),rnd.Next(80),rnd.Next(-120,120));
                    transform.position = respawn_point;
                    current_life = pv;
                    Debug.Log("frag limite" + frag_limite);
                    frag_limite--;
                }
                else
                {
                    Debug.Log("meurs");
                    DestroyObject(this.gameObject);
                    killed = true;
                }         
            }
            //this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "balle")
        {
            this.current_life -= 1;
            //Debug.Log(current_life + " script pv");
           // DestroyObject(collision.gameObject);
        }
    }

    void OnGUI()
    {
		
        if(skin != null)
            skin.label.fontSize = 70;
        GUI.skin = skin;
        if(killed)
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Perdu");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Rejouer"))
            {
                DestroyObject(this.gameObject);
                Instantiate(this.gameObject, depart.position, depart.rotation);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Retour au menu"))
                Application.LoadLevel(0);
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Quitter le jeu"))
                Application.Quit();
                
        }
    }
    public int VAFANCULO()
    {
        return this.current_life;
    }
}
