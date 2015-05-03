using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {
    public Texture2D crosshairImage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        
        float xMin = (camera.pixelWidth / 2) - (crosshairImage.width / 2);
        float yMin = (camera.pixelHeight / 2 + 4) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
    }
}
