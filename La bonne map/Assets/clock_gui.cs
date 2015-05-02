using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class clock_gui : MonoBehaviour {
    private GUIText gui_timer;
    private float startTime;
    private int time_text;
    private int limite_temps = 120; // en secondes |

	// Use this for initialization
	void Start () {
        gui_timer = gameObject.GetComponents<GUIText>()[0];
	}
	
	// Update is called once per frame
	void Update () {
        OnGui();
	}
    private void OnGui()
    {
        time_text =limite_temps - Convert.ToInt32(Time.time - startTime);
        gui_timer.text = time_text / 60 + ":" + time_text % 60;
    }
    private void Awake()
    {
        startTime = Time.time;
    }
}
