﻿using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class clock_gui : MonoBehaviour
{
    private GUIText gui_timer;
    private GameObject winner;
    private float startTime;
    private int stop = 1;
    public AudioClip endgame_sound;
    private int time_text;
    public int limite_temps = 120; // en secondes |

    public setting set;

	// Use this for initialization
	void Start () {
        gui_timer = gameObject.GetComponents<GUIText>()[0];
	}
	
	// Update is called once per frame
	void Update () {

        if ((limite_temps - Convert.ToInt32(Time.time - startTime)) < 1)
        {
            try
            {
                stop = 1 / stop;
                GameObject steveGameObject = set.all_spaceships[0];
                AudioSource shut = steveGameObject.GetComponent<AudioSource>();
                if (shut == null)
                {
                    shut = steveGameObject.GetComponentInChildren<AudioSource>();
                }
                shut.audio.clip = endgame_sound;
                shut.PlayOneShot(endgame_sound);
                stop--;

            }
            catch
            { }

            GameObject vaisseau = set.all_spaceships[0];
            int stockage = -100;
            int index = 0;
            bool egualite = false;
            for (int i = 0; i < set.all_spaceships.Length; i++)
            {
                vie life = set.all_spaceships[i].GetComponent<vie>();
                if(life == null)
                {
                    life = set.all_spaceships[i].GetComponentInChildren<vie>();
                }

                try
                {
                    set.all_spaceships[i].GetComponent<controlplayer>().enabled = false;
                }
                catch
                {
                    set.all_spaceships[i].GetComponentInChildren<controlplayer>().enabled = false;
                }

                if (life.frag_limite >= stockage)
                {
                    if (life.frag_limite == stockage)
                    {
                        egualite = true;
                    }
                    else
                    {
                        egualite = false;
                        stockage = life.frag_limite;
                        index = i;
                    }
                }
            }

            if (!egualite)
            {
                try
                {
                    set.all_spaceships[index].GetComponent<vie>().gameover(set.all_spaceships[index].GetComponent<vie>().name + " WIN");
                }
                catch
                {
                    set.all_spaceships[index].GetComponentInChildren<vie>().gameover(set.all_spaceships[index].GetComponentInChildren<vie>().name + " WIN");
                }
            }
            else
            {
                try
                {
                    set.all_spaceships[0].GetComponent<vie>().gameover("GAME DRAW");
                }
                catch
                {
                    set.all_spaceships[index].GetComponentInChildren<vie>().gameover("GAME DRAW");
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
