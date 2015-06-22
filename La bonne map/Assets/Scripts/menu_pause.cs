using UnityEngine;
using System.Collections;
using UnityEditor;

public class menu_pause : MonoBehaviour
{

    int paused = 0;
    int temp = 4; // a changer 
    int temp2;
    float volume;
    bool changed_sound = false;
    public GUISkin skin;
    AudioListener main;

    void Start()
    {
        volume = this.camera.audio.volume;
        if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.Disable)
        {
            temp2 = 0;
        }
        else
        {
            if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.Enable)
            {
                temp2 = 1;
            }
            else
            {
                temp2 = 2;
            }
        }
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
            string[] toolbarStrings = new string[] { "Mono", "Stereo", "Quad", "Surround", "5.1", "7.1"};
            int var = 0;
            var = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 55, 800, 25), var, toolbarStrings);
            switch (var)
            {
                case 0:
                    AudioSettings.speakerMode = AudioSpeakerMode.Mono;
                    break;
                case 1:
                    AudioSettings.speakerMode = AudioSpeakerMode.Stereo;
                    break;
                case 2:
                    AudioSettings.speakerMode = AudioSpeakerMode.Quad;
                    break;
                case 3:
                    AudioSettings.speakerMode = AudioSpeakerMode.Surround;
                    break;
                case 4:
                    AudioSettings.speakerMode = AudioSpeakerMode.Mode5point1;
                    break;
                case 5:
                    AudioSettings.speakerMode = AudioSpeakerMode.Mode7point1;
                    break;
            }

        }
        if (paused == 4) // Touches
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");
        }
        if (paused == 5) // Video
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");

            GUI.Box(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 150, 300,25), "Anisotropic Textures");
            string[] toolbarStrings = new string[] { "Disable", "Enable", "ForceEnable" };
            int var = temp;
            var = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 85, 800, 25), var, toolbarStrings);
            switch (var)
            {
                case 0:
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                    break;
                case 1:
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                    break;
                case 2:
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                    break;
            }
            temp = var;
            var = temp2;
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 900, Screen.height / 5), "Anti Aliasing");
            toolbarStrings = new string[] {"0" ,"2x", "4x", "8x"};
            var = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 10, 800, 25), var, toolbarStrings);
            switch (var)
            {
                case 0:
                    QualitySettings.antiAliasing = 0;
                    break;
                case 1:
                    QualitySettings.antiAliasing = 2;
                    break;
                case 2:
                    QualitySettings.antiAliasing = 4;
                    break;
                case 3:
                    QualitySettings.antiAliasing = 8;
                    break;
            }
            temp2 = var;
            bool coche = QualitySettings.softVegetation;
            coche = GUI.Toggle(new Rect(Screen.width / 2 - 130, Screen.height / 2 + 50, 800, 25), coche, "Soft Particles");
            QualitySettings.softVegetation = coche;
            float v_number = 1;
            string lengthText = GUI.TextField(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 90, 300, 25), v_number.ToString());
            float newLength;
            if (float.TryParse(lengthText, out newLength))
            {
                v_number = newLength;
            }
            Debug.Log("AA : " + temp + " filtre : " + temp2);
        }
    }
}
