using UnityEngine;
using System.Collections;

public class end_tuto : MonoBehaviour {
int ok =0;
public GUISkin hue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	void OnCollisionEnter(Collision collision)
	{
	ok = 1;
		StartCoroutine(W8M8());
	}
	IEnumerator W8M8()
	{
		yield return new WaitForSeconds(3.0f);
		ok = 2;
		Application.LoadLevel(0);
	}
	void OnGUI()
	{
		if (ok ==1)
		{
		GUI.skin = hue;
			GUI.Label(new Rect(Screen.width / 2 - 340 , Screen.height / 2 - 80, 900, 90), "CONGRATULATION");
		}
	}
}
