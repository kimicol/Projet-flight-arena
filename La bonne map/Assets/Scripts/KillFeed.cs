using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillFeed : MonoBehaviour {
	// Use this for initialization
    List<vie> vaisseaux = new List<vie>();
    string[,] mort = new string[10,3];
    int x = 0;

	void Start ()
    {
        foreach (var item in GetComponentsInChildren<vie>())
        {
            //Debug.Log(item.name);
            vaisseaux.Add(item);
        }
        vaisseaux.RemoveRange(vaisseaux.Count - 2,vaisseaux.Count - 2);
	}
	
	// Update is called once per frame
	void Update () 
    {
        foreach (var item in vaisseaux)
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
	}
    IEnumerator W8M8()
    {
        yield return new WaitForSeconds(2.0f);
        x--;
        mort[0, 0] = ""; mort[0, 1] = "";
        for (int i = 0; i < x -1; i++)
        {
            mort[i, 0] = mort[i + 1, 0];
            mort[i, 1] = mort[i + 1, 1];
        }
    }
    void OnGUI()
    {
        for (int w = 0; w < x; w++)
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            string coul;
            if (mort[w,2] == "red")
            {
                coul = "blue";
            }
            else
            {
                coul = "red";
            }
            GUI.Label(new Rect(1, 1 + 20 * w, 300, 25),"<size=20>" +"<color="+ coul + ">" + mort[w, 0] + "</color>" + " has slain " + "<color=" + mort[w,2] + ">" + mort[w, 1] + "</color>" + "</size>" ,style);
        }
    }
}
