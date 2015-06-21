using UnityEngine;
using System.Collections;

public class menu_pause : MonoBehaviour {

    int paused = 0;
    public GUISkin skin;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused == 0)
            {
                paused = 1;
                Time.timeScale = 1f;
            }
            else
            {
                paused = 0;
                Time.timeScale = 0f;
            }
        }
        Debug.Log(Time.timeScale + " paused" + paused);

    }

    void OnGUI()
    {
        skin.label.fontSize = 70;
        GUI.skin = skin;
        if (Time.timeScale == 0f)
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au jeu"))
            { paused = 0; Time.timeScale = 1f; }
            
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Options"))
            {
                Destroy(this.gameObject);
                paused = 2;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Retour au menu"))
                Application.LoadLevel(0);
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Quitter le jeu"))
                Application.Quit();
        }
        if (paused == 2)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au menu principal"))
                paused = 1;
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Réglages des touches"))
                paused = 3;
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 0, 300, 25), "Son"))
                paused = 4;
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Réglages des touches"))
                paused = 5;
        }
    }
}
