using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillFeed : MonoBehaviour {
	// Use this for initialization
    List<vie> vaisseaux = new List<vie>();
    string[,] mort = new string[10,2];
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
                Debug.Log("name" + item.name + " tueur" + item.tueur);
                mort[x, 0] = item.tueur;
                mort[x, 1] = item.name;
                x++;
                item.bool_killfeed = false;
                StartCoroutine(W8M8());
            }
        }
            for (int i = 0; i < x; i++)
            {
                Debug.Log("val i " + i + " " + mort[i, 0] + " 1-> " + mort[i, 1]);
            }
	}
    IEnumerator W8M8()
    {
        yield return new WaitForSeconds(5.0f);
        x--;
        mort[0, 0] = ""; mort[0, 1] = "";
        for (int i = 0; i < x -1; i++)
        {
            mort[i, 0] = mort[i + 1, 0];
            mort[i, 1] = mort[i + 1, 1];
        }
    }
}
