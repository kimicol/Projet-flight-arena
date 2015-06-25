using UnityEngine;
using System.Collections;
using UnityEditor;

public class menu_pause : MonoBehaviour
{

    int paused = 0;
    int aliasing = 8; // a changer 
    int anisotropic;
    private float volume;
    bool changed_sound = false;
    public GUISkin skin;
    AudioListener main;

    private int qualite_image = 0;
    private int son = 0;

    void Start()
    {
        //volume = this.camera.audio.volume;
        volume = PlayerPrefs.GetFloat("Volume", volume);
        if (PlayerPrefs.HasKey("Volume"))
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        else
            PlayerPrefs.SetFloat("Volume", volume);

        son = PlayerPrefs.GetInt("son", son);
        if (PlayerPrefs.HasKey("son"))
        {
            son = PlayerPrefs.GetInt("son", son);
            switch (son)
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
        else
            PlayerPrefs.SetInt("son", son);

        qualite_image = PlayerPrefs.GetInt("qualite_image", qualite_image);
        if (PlayerPrefs.HasKey("qualite_image"))
        {
            qualite_image = PlayerPrefs.GetInt("qualite_image", qualite_image);
            QualitySettings.SetQualityLevel(qualite_image);
        }
        else
            PlayerPrefs.SetInt("qualite_image", qualite_image);

        aliasing = PlayerPrefs.GetInt("aliasing", aliasing);
        if (PlayerPrefs.HasKey("aliasing"))
        {
            aliasing = PlayerPrefs.GetInt("aliasing", aliasing);
            switch (aliasing)
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
        }
        else
            PlayerPrefs.SetInt("aliasing", aliasing);

        anisotropic = PlayerPrefs.GetInt("anisotropic", anisotropic);
        if (PlayerPrefs.HasKey("anisotropic"))
        {
            qualite_image = PlayerPrefs.GetInt("anisotropic", anisotropic);
            switch (anisotropic)
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
        }
        else
            PlayerPrefs.SetInt("anisotropic", anisotropic);
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
        skin.label.fontSize = 70;
        GUI.skin = skin;

        if (paused != 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 6, Screen.width / 2, Screen.height / 5), "Pause");
            skin.label.fontSize = 20;
            GUI.skin = skin;
        }

        if (paused == 1) // Menu principal
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au jeu"))
            { 
                paused = 0;
                Time.timeScale = 1f; 
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Options"))
                paused = 2; 
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Retour au menu"))
                Application.LoadLevel(0);
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Quitter le jeu"))
                Application.Quit();
        }
        else if (paused == 2) // option
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Retour au menu principal"))
            { paused = 1; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), "Son"))
            { paused = 3; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 25), "Réglage des touches"))
                paused = 4;
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 25), "Vidéo"))
            { paused = 5; }
        }
        else if (paused == 3) // son
        {
            #region son
            //Changement du volume
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 300, 25), "Volume");
            volume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 25), volume, 0.0F, 1.0F); // A verifier sur quelle valeur est change et difference avec valeur du menu
            string lengthText = GUI.TextField(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 20, 300, 25), volume.ToString());
            float newLength;
            if (float.TryParse(lengthText, out newLength))
            {
                volume = newLength;
            }
            PlayerPrefs.SetFloat("Volume", volume);

            string[] toolbarStrings = new string[] { "Mono", "Stéréo", "Quad", "Surround", "5.1", "7.1" };
            int var = 0;
            var = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 50, 800, 25), var, toolbarStrings);
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

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 140, 300, 25), "Retour au menu principal"))
            { paused = 1; }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 25), "Retour au menu Options"))
            { paused = 2; }
            #endregion
        }
        else if (paused == 4) // Touches
        {
            #region touches
            string[] toolbarStrings = new string[] { "Avancer", "Rotation Haut", "Rotation Bas", "Pivoter gauche", "Pivoter Droite", "Rotation Gauche", "Rotation Droite", "Tirer" };
            GUI.SelectionGrid(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 160, 200, 200), 0, toolbarStrings, 1);
            GameObject bob = GameObject.Find("Vaisseaux");
            inputs touche_1 = bob.GetComponentsInChildren<inputs>()[0];
            string key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 160, 150, 20), touche_1.used_keys[0].ToString());
            try { touche_1.used_keys[0] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 133, 150, 20), KeyCode.UpArrow.ToString());
            try { touche_1.used_keys[1] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 107, 150, 20), KeyCode.DownArrow.ToString());
            try { touche_1.used_keys[2] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 83, 150, 20), touche_1.used_keys[3].ToString());
            try { touche_1.used_keys[3] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 57, 150, 20), touche_1.used_keys[4].ToString());
            try { touche_1.used_keys[4] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 32, 150, 20), KeyCode.LeftArrow.ToString());
            try { touche_1.used_keys[5] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 7, 150, 20), KeyCode.RightArrow.ToString());
            try { touche_1.used_keys[6] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            key = GUI.TextField(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 19, 150, 20), KeyCode.Space.ToString());
            try { touche_1.used_keys[7] = (KeyCode)System.Enum.Parse(typeof(KeyCode), key); }
            catch { }
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 80, 300, 25), "Retour au menu Options"))
            { paused = 2; }
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 110, 300, 25), "Retour au menu principal"))
            { paused = 1; }
            #endregion
        }
        else if (paused == 5) // Video
        {
            #region video
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 160, 300, 25), "Anisotropic Textures");
            string[] toolbarStrings = new string[] { "Disable", "Enable", "Force Enable" };
            anisotropic = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 125, 800, 25), anisotropic, toolbarStrings);
            switch (anisotropic)
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
            PlayerPrefs.SetInt("anisotropic", anisotropic);

            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 60, 300, 25), "Anti Aliasing");
            toolbarStrings = new string[] { "0", "2x", "4x", "8x" };
            aliasing = GUI.Toolbar(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 20, 800, 25), aliasing, toolbarStrings);
            switch (aliasing)
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
            PlayerPrefs.SetInt("aliasing", aliasing);

            bool coche = QualitySettings.softVegetation;
            coche = GUI.Toggle(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 20, 800, 25), coche, "Soft Particles");
            QualitySettings.softVegetation = coche;
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 60, 300, 25), "Luminosité");

            Light lt = GameObject.FindObjectOfType<Light>();
            float lumi = lt.intensity;
            lumi = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 100, 300, 25), lumi, 0.0F, 1.0F);
            string lengthText = GUI.TextField(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 125, 300, 25), lumi.ToString());
            float newLength;
            if (float.TryParse(lengthText, out newLength))
            {
                lt.intensity = newLength;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 180, 300, 25), "Retour au menu Options"))
            { paused = 2; }
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 + 220, 300, 25), "Retour au menu principal"))
            { paused = 1; }

            //Debug.Log("AA : " + temp + " filtre : " + temp2);
            #endregion
        }
    }
}
