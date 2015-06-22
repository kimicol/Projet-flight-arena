using UnityEngine;
using System.Collections;

public class menu_pause : MonoBehaviour
{

    int paused = 0;
    float volume;
    bool changed_sound = false;
    public GUISkin skin;
    AudioListener main;

    void Start()
    {
        volume = this.camera.audio.volume;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused == 0)
            {
                paused = 1;
                Time.timeScale = 0f;
            }
            else
            {
                paused = 0;
                Time.timeScale = 1f;
            }
        }
        if (changed_sound)
        {
            foreach (var a in FindObjectsOfType<AudioSource>()) // si split screen
                a.volume = volume;
            changed_sound = false;
        }
    }

    void OnGUI()
    {
        Debug.Log(paused);
        skin.label.fontSize = 70;
        GUI.skin = skin;
        if (paused == 1) // Menu principal
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au jeu"))
            { paused = 0; Time.timeScale = 1f; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Options"))
            { paused = 2; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Retour au menu"))
                Application.LoadLevel(0);
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Quitter le jeu"))
                Application.Quit();
        }
        if (paused == 2) // option
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au menu principal"))
            { paused = 1; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Son"))
            { paused = 3; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Reglage des touches"))
                paused = 4;
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Video"))
            { paused = 5; }
        }
        if (paused == 3) // son
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au menu principal"))
            { paused = 1; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Retour au menu Options"))
            { paused = 2; }
            volume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), volume, 0.0F, 1.0F); // A verifier sur quelle valeur est change et difference avec valeur du menu
            string lengthText = GUI.TextField(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 20, 300, 25), volume.ToString());
            float newLength;
            if (float.TryParse(lengthText, out newLength))
            {
                volume = newLength;
            }
        }
    }
}
