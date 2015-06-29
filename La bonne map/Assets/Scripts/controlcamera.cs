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
    int x = 0;

	// Use this for initialization
	void Start ()
    {
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
        /*
        Debug.Log(camera.rect.y);
        if (this.camera.rect.yMax == 1)
        {
            GUI.Label(new Rect(Screen.width - 50, (0.5f * Screen.height) - 30, 50, 30), "" + vie_restante.current_life);
        }
        else
        {
            GUI.Label(new Rect(Screen.width - 50, (Screen.height) - 30, 50, 30), "" + vie_restante.current_life);
        }
        */
        GUI.Label(new Rect(Screen.width - 50, (camera.rect.y + 0.5f) * Screen.height - 30, 50, 30), "" + vie_restante.current_life);

        for (int w = 0; w < x; w++)
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string coul;
            if (mort[w, 2] == "red")
            {
                coul = "blue";
            }
            else
            {
                coul = "red";
            }
            GUI.Label(new Rect(1, (camera.rect.y + 0.5f) * Screen.height + (1 + 20 * w), 300, 25), "<size=20>" + "<color=" + coul + ">" + mort[w, 0] + "</color>" + " has slain " + "<color=" + mort[w, 2] + ">" + mort[w, 1] + "</color>" + "</size>", style);
        }
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

        foreach (var item in all_vaisseaux)
        {
            if (item.bool_killfeed)
            {
                bool b = true;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < all_vaisseaux.Length; j++)
                    {
                        b = b && all_vaisseaux[j].name != mort[i, 1];
                    }
                }

                if (b)
                {
                    //Debug.Log("name" + item.name + " tueur" + item.tueur);
                    mort[x, 0] = item.tueur;
                    mort[x, 1] = item.name;
                    mort[x, 2] = item.couleur;
                    x++;
                    item.bool_killfeed = false;
                    StartCoroutine(W8M8());
                }
            }
        }
    }

    IEnumerator W8M8()
    {
        yield return new WaitForSeconds(2.0f);
        x--;
        mort[0, 0] = ""; mort[0, 1] = "";
        for (int i = 0; i < x - 1; i++)
        {
            mort[i, 0] = mort[i + 1, 0];
            mort[i, 1] = mort[i + 1, 1];
        }
    }
}
