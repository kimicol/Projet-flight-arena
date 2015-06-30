using UnityEngine;
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
            GameObject steveGameObject;
            try
            {
                stop = 1 / stop;
                try { steveGameObject = set.all_spaceships[0]; Debug.Log("Propre"); }
                catch { steveGameObject = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI"); }
                AudioSource shut = steveGameObject.GetComponent<AudioSource>();
                Debug.Log("avant");
                if (shut == null)
                {
                    Debug.Log("pdnt");
                    shut = steveGameObject.GetComponentInChildren<AudioSource>();
                }
                Debug.Log("apres");
                shut.audio.clip = endgame_sound;
                shut.PlayOneShot(endgame_sound);
                Debug.Log("debug son");
                stop--;

            }
            catch
            { }
            try
            {
                foreach (var item in set.all_spaceships)
	{
        item.GetComponent<controlcamera>();
	}
            }
            catch { Debug.Log("non"); }
            vie john = GameObject.Find("IL EST BEAU LE VAISSEAU OUI OUI").GetComponent<vie>();
            john.gameover("GAME DRAW");
            
            //GameObject vaisseau = set.all_spaceships[0];
          /*  int stockage = -100;
            int index = 0;
            bool egalite = false;
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
                        egalite = true;
                    }
                    else
                    {
                        egalite = false;
                        stockage = life.frag_limite;
                        index = i;
                    }
                }
            }

            if (!egalite)
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
            } */
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
