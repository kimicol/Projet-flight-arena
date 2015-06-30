using UnityEngine;
using System.Collections;
using System.Net;

public class controlcameramulti : MonoBehaviour
{
    public Transform vaisseau;
    //public vie vie_restante;
    public GUISkin sk;

    public vie vie_restante;
    public GameObject[] vvv;
    private vie[] all_vaisseaux;
    string[,] mort; // = new string[vvv.Length, 3];
    int x = 0;

    void Awake()
    {
        camera.enabled = networkView.isMine;
        //vie_restante = vaisseau.GetComponents<vie>()[0];

        vie_restante = vaisseau.GetComponent<vie>();
    }

	// Use this for initialization
	void Start ()
    {
        mort = new string[vvv.Length, 3];
        all_vaisseaux = new vie[vvv.Length];

        for (int i = 0; i < vvv.Length; i++)
        {
            if (vvv[i] != null)
            {
                all_vaisseaux[i] = vvv[i].GetComponent<vie>();
                if (all_vaisseaux[i] == null)
                {
                    all_vaisseaux[i] = vvv[i].GetComponentInChildren<vie>();
                }
            }
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        if (vaisseau != null)
        {
            this.transform.rotation = vaisseau.transform.rotation;
            this.transform.position = vaisseau.transform.position;
            this.transform.Translate(new Vector3(0f, 3f, -9f));
        }
        
        for (int i = 0; i < vvv.Length; i++)
        {
            if (vvv[i] != null)
            {
                all_vaisseaux[i] = vvv[i].GetComponent<vie>();
                if (all_vaisseaux[i] == null)
                {
                    all_vaisseaux[i] = vvv[i].GetComponentInChildren<vie>();
                }
            }
        }

        foreach (var item in all_vaisseaux)
        {
            try
            {
                if (item.bool_killfeed)
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
            catch { }
        }
    }

    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Server)
        {
            string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();

            GUI.Label(new Rect(0, 0, 100, 30), ip);
        }

        //GUI.skin = sk;
        //GUI.Label(new Rect(Screen.width - 50, Screen.height - 30, 50, 30), "" + vie_restante.current_life);

        GUI.skin = sk;

        if (vie_restante.current_life < 0)
            vie_restante.current_life = 0;
        GUI.Label(new Rect(Screen.width - 50, (camera.rect.yMax) * Screen.height - 30, 50, 30), "" + vie_restante.current_life);

        //Debug.Log(camera.rect.yMax);
        if (vie_restante.frag_limite <= 0)
            this.camera.enabled = false;

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
            GUI.Label(new Rect(1, 1 + 20 * w, 300, 25), "<size=20>" + "<color=" + coul + ">" + mort[w, 0] + "</color>" + " has slain " + "<color=" + mort[w, 2] + ">" + mort[w, 1] + "</color>" + "</size>", style);
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
