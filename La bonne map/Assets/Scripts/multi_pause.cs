using UnityEngine;
using System.Collections;

public class multi_pause : MonoBehaviour {

    bool paused = false;
    public GUISkin skin;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            paused = mise_en_pause();
    }

    void OnGUI()
    {
        skin.label.fontSize = 70;
        GUI.skin = skin;
        if (paused)
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Retour au jeu"))
                paused = mise_en_pause();

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Retour au menu"))
            {
                Network.Disconnect();
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Quitter le jeu"))
            {
                Network.Disconnect();
                Application.Quit();
            }
        }
    }

    bool mise_en_pause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
