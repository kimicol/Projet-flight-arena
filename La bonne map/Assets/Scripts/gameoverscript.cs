using UnityEngine;
using System.Collections;

public class gameoverscript : MonoBehaviour
{
    private GUIText thewinner;
    // Use this for initialization
    void Start()
    {
        thewinner = gameObject.GetComponents<GUIText>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void launch(string name)
    {
        thewinner.text = name + " WIN";
    }
}
