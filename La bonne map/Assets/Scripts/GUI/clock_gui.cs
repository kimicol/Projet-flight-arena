using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class clock_gui : MonoBehaviour {
    private GUIText gui_timer;
    private GameObject winner;
    private float startTime;
    private int time_text;
    public int limite_temps = 120; // en secondes |

	// Use this for initialization
	void Start () {
        gui_timer = gameObject.GetComponents<GUIText>()[0];
	}
	
	// Update is called once per frame
	void Update () {
        
        if ((limite_temps - Convert.ToInt32(Time.time - startTime)) <1)
        {
        winner = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI");
        vie bob = winner.GetComponent<vie>();
        int stockage = bob.frag_limite;
        winner = GameObject.Find("le him is le player 2");
        bob = winner.GetComponent<vie>();
        if (bob.frag_limite < stockage)
        {
            bob.gameover("PLAYER 1 WIN");
        }
        else
        {
            if (bob.frag_limite > stockage)
            {
                bob.gameover("PLAYER 2 WIN");
            }
            else
            {
                bob.gameover("GAME DRAW");
            }
        }
        }
	}
    private void OnGUI()
    {
        time_text =limite_temps - Convert.ToInt32(Time.time - startTime);
        gui_timer.text = (time_text / 60 + ":" + time_text % 60);
    }
    private void Awake()
    {
        startTime = Time.time;
    }
}
