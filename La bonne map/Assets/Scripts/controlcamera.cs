using UnityEngine;
using System.Collections;

public class controlcamera : MonoBehaviour
{
    public Transform vaisseau;
    public vie vie_restante;
    public GUISkin sk;

    public GameObject[] vvv;
    private vie[] all_vaisseaux;
    string[,] mort; // = new string[vvv.Length, 3];

    int mode_jeu = 1;

	// Use this for initialization
	void Start ()
    {
        mode_jeu = PlayerPrefs.GetInt("mode_jeu", mode_jeu);
        if (PlayerPrefs.HasKey("mode_jeu"))
        {
            mode_jeu = PlayerPrefs.GetInt("mode_jeu", mode_jeu);
        }
        else
        {
            PlayerPrefs.SetInt("mode_jeu", mode_jeu);
        }

        vie_restante = vaisseau.GetComponent<vie>();

        mort = new string[vvv.Length, 3];
        all_vaisseaux = new vie[vvv.Length];
        for (int i = 0; i < vvv.Length; i++)
        {
            all_vaisseaux[i] = vvv[i].GetComponent<vie>();
            if(all_vaisseaux[i] == null)
            {
                all_vaisseaux[i] = vvv[i].GetComponentInChildren<vie>();
            }
        }
	}

    void OnGUI()
    {
        GUI.skin = sk;
        
        if (mode_jeu == 2)
        {
            if (vie_restante.current_life < 0)
                vie_restante.current_life = 0;
            if (camera.rect.yMax == 1f)
                GUI.Label(new Rect(Screen.width - 50, 0.5f * Screen.height - 30, 50, 30), "" + vie_restante.current_life);
            else
                GUI.Label(new Rect(Screen.width - 50, Screen.height - 30, 50, 30), "" + vie_restante.current_life);
        }
        else
        {
            if (vie_restante.current_life < 0)
                vie_restante.current_life = 0;
            GUI.Label(new Rect(Screen.width - 50, (camera.rect.yMax) * Screen.height - 30, 50, 30), "" + vie_restante.current_life);
        }
        //Debug.Log(camera.rect.yMax);
        if (vie_restante.frag_limite <= 0)
            this.camera.enabled = false;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (vaisseau != null)
        {
            this.transform.position = vaisseau.transform.position;
            this.transform.Translate(new Vector3(0f, 3f, -9f));
            this.transform.rotation = vaisseau.transform.rotation;
        }
    }
}
